using Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Client.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JavaScriptSerializer _serializer;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl.TrimEnd('/') + "/")
            };
            _serializer = new JavaScriptSerializer();
        }

        public string Token { get; private set; }
        public AuthResponseDto CurrentUser { get; private set; }

        public async Task<ApiEnvelope<AuthResponseDto>> LoginAsync(string email, string password)
        {
            var payload = new LoginRequestDto
            {
                email = email,
                password = password
            };

            var result = await PostAsync<AuthResponseDto>("api/auth/login", payload);

            if (result != null && result.success && result.data != null)
            {
                CurrentUser = result.data;
                Token = result.data.token;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            return result;
        }

        public Task<ApiEnvelope<AuthResponseDto>> RegisterAsync(string name, string email, string password, int role)
        {
            var payload = new RegisterRequestDto
            {
                name = name,
                email = email,
                password = password,
                role = role
            };

            return PostAsync<AuthResponseDto>("api/auth/register", payload);
        }

        public async Task<ApiEnvelope<PagedResultDto<TripResponseDto>>> GetTripsAsync(string city, DateTime? date, int pageNumber, int pageSize)
        {
            var query = new List<string>();

            if (!string.IsNullOrWhiteSpace(city))
            {
                query.Add("city=" + Uri.EscapeDataString(city));
            }

            if (date.HasValue)
            {
                query.Add("date=" + Uri.EscapeDataString(date.Value.ToString("o")));
            }

            query.Add("pageNumber=" + pageNumber);
            query.Add("pageSize=" + pageSize);

            var endpoint = "api/trips";
            if (query.Count > 0)
            {
                endpoint += "?" + string.Join("&", query);
            }

            return await GetAsync<PagedResultDto<TripResponseDto>>(endpoint);
        }

        public Task<ApiEnvelope<TripResponseDto>> CreateTripAsync(
            string departure,
            string destination,
            DateTime startDate,
            DateTime endDate,
            TimeSpan startTime,
            decimal pricePerSeat,
            int availableSeats)
        {
            var departureDateTime = startDate.Date.Add(startTime);
            var numberOfDays = Math.Max(1, (endDate.Date - startDate.Date).Days + 1);

            var payload = new TripCreateDto
            {
                departure = departure,
                destination = destination,
                departureTime = departureDateTime.ToUniversalTime().ToString("o"),
                startDate = startDate.Date.ToString("o"),
                endDate = endDate.Date.ToString("o"),
                startTime = startTime.ToString(),
                numberOfDays = numberOfDays,
                pricePerSeat = pricePerSeat,
                availableSeats = availableSeats
            };

            return PostAsync<TripResponseDto>("api/trips", payload);
        }

        public Task<ApiEnvelope<object>> DeleteTripAsync(int tripId)
        {
            return DeleteAsync<object>("api/trips/" + tripId);
        }

        public Task<ApiEnvelope<object>> DeleteAdminTripAsync(int tripId)
        {
            return DeleteAsync<object>("api/admin/trips/" + tripId);
        }

        public Task<ApiEnvelope<ReservationResponseDto>> CreateReservationAsync(
            int tripId,
            int seats,
            string paymentMethod,
            string cardHolderName = null,
            string cardNumber = null,
            string expiryDate = null,
            string cvv = null)
        {
            var payload = new ReservationCreateDto
            {
                tripId = tripId,
                seats = seats,
                paymentMethod = paymentMethod,
                cardHolderName = cardHolderName,
                cardNumber = cardNumber,
                expiryDate = expiryDate,
                cvv = cvv
            };

            return PostAsync<ReservationResponseDto>("api/reservations", payload);
        }

        public Task<ApiEnvelope<List<ReservationResponseDto>>> GetReservationsAsync()
        {
            return GetAsync<List<ReservationResponseDto>>("api/reservations");
        }

        public Task<ApiEnvelope<List<AdminUserDto>>> GetAdminUsersAsync()
        {
            return GetAsync<List<AdminUserDto>>("api/admin/users");
        }

        public Task<ApiEnvelope<List<TripResponseDto>>> GetAdminTripsAsync()
        {
            return GetAsync<List<TripResponseDto>>("api/admin/trips");
        }

        public Task<ApiEnvelope<List<AdminReservationDto>>> GetAdminReservationsAsync()
        {
            return GetAsync<List<AdminReservationDto>>("api/admin/reservations");
        }

        public Task<ApiEnvelope<List<ReservationResponseDto>>> GetTripReservationsAsync(int tripId)
        {
            return GetAsync<List<ReservationResponseDto>>("api/trips/" + tripId + "/reservations");
        }

        public Task<ApiEnvelope<ReviewResponseDto>> CreateReviewAsync(int tripId, int rating, string comment)
        {
            var payload = new ReviewCreateDto
            {
                tripId = tripId,
                rating = rating,
                comment = comment
            };

            return PostAsync<ReviewResponseDto>("api/reviews", payload);
        }

        public Task<ApiEnvelope<List<ReviewResponseDto>>> GetDriverReviewsAsync(int driverId)
        {
            return GetAsync<List<ReviewResponseDto>>("api/reviews/driver/" + driverId);
        }

        public Task<ApiEnvelope<DriverProfileDto>> GetDriverProfileAsync(int driverId)
        {
            return GetAsync<DriverProfileDto>("api/drivers/" + driverId + "/profile");
        }

        public Task<ApiEnvelope<List<PaymentResponseDto>>> GetAdminPaymentsAsync()
        {
            return GetAsync<List<PaymentResponseDto>>("api/admin/payments");
        }

        public Task<ApiEnvelope<List<PaymentResponseDto>>> GetPaymentsAsync()
        {
            return GetAsync<List<PaymentResponseDto>>("api/payments");
        }

        public Task<ApiEnvelope<AuthorResponseDto>> GetAuthorByUserIdAsync(int userId)
        {
            return GetAsync<AuthorResponseDto>("api/authors/" + userId);
        }

        public Task<ApiEnvelope<AuthorResponseDto>> CreateAuthorAsync(AuthorCreateDto payload)
        {
            return PostAsync<AuthorResponseDto>("api/authors", payload);
        }

        public Task<ApiEnvelope<AuthorResponseDto>> UpdateAuthorAsync(int authorId, AuthorUpdateDto payload)
        {
            return PutAsync<AuthorResponseDto>("api/authors/" + authorId, payload);
        }

        public Task<ApiEnvelope<object>> DeleteReservationAsync(int reservationId)
        {
            return DeleteAsync<object>("api/reservations/" + reservationId);
        }

        public Task<ApiEnvelope<object>> DeleteAdminReservationAsync(int reservationId)
        {
            return DeleteAsync<object>("api/admin/reservations/" + reservationId);
        }

        private async Task<ApiEnvelope<T>> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            return await ReadEnvelopeAsync<T>(response);
        }

        private async Task<ApiEnvelope<T>> PostAsync<T>(string endpoint, object payload)
        {
            var json = _serializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            return await ReadEnvelopeAsync<T>(response);
        }

        private async Task<ApiEnvelope<T>> DeleteAsync<T>(string endpoint)
        {
            var response = await _httpClient.DeleteAsync(endpoint);
            return await ReadEnvelopeAsync<T>(response);
        }

        private async Task<ApiEnvelope<T>> PutAsync<T>(string endpoint, object payload)
        {
            var json = _serializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endpoint, content);
            return await ReadEnvelopeAsync<T>(response);
        }

        private async Task<ApiEnvelope<T>> ReadEnvelopeAsync<T>(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(body))
            {
                return new ApiEnvelope<T>
                {
                    success = response.IsSuccessStatusCode,
                    message = response.IsSuccessStatusCode ? "Success" : "Empty response"
                };
            }

            ApiEnvelope<T> envelope;

            try
            {
                envelope = _serializer.Deserialize<ApiEnvelope<T>>(body);
            }
            catch
            {
                envelope = new ApiEnvelope<T>
                {
                    success = false,
                    message = "Invalid server response"
                };
            }

            if (envelope == null)
            {
                envelope = new ApiEnvelope<T>
                {
                    success = false,
                    message = "No response data"
                };
            }

            if (!response.IsSuccessStatusCode && string.IsNullOrWhiteSpace(envelope.message))
            {
                envelope.message = response.ReasonPhrase;
            }

            return envelope;
        }
    }
}

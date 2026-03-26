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

        public Task<ApiEnvelope<TripResponseDto>> CreateTripAsync(string departure, string destination, DateTime date, int availableSeats)
        {
            var payload = new TripCreateDto
            {
                departure = departure,
                destination = destination,
                date = date.ToString("o"),
                availableSeats = availableSeats
            };

            return PostAsync<TripResponseDto>("api/trips", payload);
        }

        public Task<ApiEnvelope<object>> DeleteTripAsync(int tripId)
        {
            return DeleteAsync<object>("api/trips/" + tripId);
        }

        public Task<ApiEnvelope<ReservationResponseDto>> CreateReservationAsync(int tripId, int seatsReserved)
        {
            var payload = new ReservationCreateDto
            {
                tripId = tripId,
                seatsReserved = seatsReserved
            };

            return PostAsync<ReservationResponseDto>("api/reservations", payload);
        }

        public Task<ApiEnvelope<List<ReservationResponseDto>>> GetReservationsAsync()
        {
            return GetAsync<List<ReservationResponseDto>>("api/reservations");
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

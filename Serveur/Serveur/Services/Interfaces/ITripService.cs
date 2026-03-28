using Serveur.DTOs.Reservations;
using Serveur.DTOs.Trips;

namespace Serveur.Services.Interfaces;

public interface ITripService
{
    Task<PagedResultDto<TripResponseDto>> GetTripsAsync(TripQueryParamsDto query, CancellationToken cancellationToken = default);
    Task<TripResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TripResponseDto> CreateAsync(int driverId, TripCreateDto request, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReservationResponseDto>> GetTripReservationsAsync(int tripId, int currentUserId, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, int userId, CancellationToken cancellationToken = default);
}

using Serveur.DTOs.Reservations;

namespace Serveur.Services.Interfaces;

public interface IReservationService
{
    Task<ReservationResponseDto> CreateAsync(int userId, ReservationCreateDto request, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReservationResponseDto>> GetUserReservationsAsync(int userId, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, int userId, CancellationToken cancellationToken = default);
}

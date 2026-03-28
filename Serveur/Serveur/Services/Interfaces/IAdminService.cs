using Serveur.DTOs.Admin;
using Serveur.DTOs.Payments;
using Serveur.DTOs.Trips;

namespace Serveur.Services.Interfaces;

public interface IAdminService
{
    Task<IReadOnlyList<AdminUserDto>> GetUsersAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TripResponseDto>> GetTripsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AdminReservationDto>> GetReservationsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PaymentResponseDto>> GetPaymentsAsync(CancellationToken cancellationToken = default);
    Task DeleteUserAsync(int id, CancellationToken cancellationToken = default);
    Task DeleteTripAsync(int id, CancellationToken cancellationToken = default);
    Task DeleteReservationAsync(int id, CancellationToken cancellationToken = default);
    Task DeletePaymentAsync(int id, CancellationToken cancellationToken = default);
}

using Serveur.Models.Entities;

namespace Serveur.Repositories.Interfaces;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Reservation?> GetByIdForUpdateAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Reservation>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Reservation>> GetAllByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Reservation>> GetAllByTripIdAsync(int tripId, CancellationToken cancellationToken = default);
    Task<int> CountByDriverIdAsync(int driverId, CancellationToken cancellationToken = default);
    Task<bool> ExistsByUserAndTripAsync(int userId, int tripId, CancellationToken cancellationToken = default);
    Task AddAsync(Reservation reservation, CancellationToken cancellationToken = default);
    Task DeleteAsync(Reservation reservation, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

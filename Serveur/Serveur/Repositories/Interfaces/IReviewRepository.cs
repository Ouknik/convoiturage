using Serveur.Models.Entities;

namespace Serveur.Repositories.Interfaces;

public interface IReviewRepository
{
    Task<Review?> GetByPassengerAndTripAsync(int passengerId, int tripId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Review>> GetByDriverIdAsync(int driverId, CancellationToken cancellationToken = default);
    Task AddAsync(Review review, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

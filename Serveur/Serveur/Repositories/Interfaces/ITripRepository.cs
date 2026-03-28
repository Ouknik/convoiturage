using Serveur.DTOs.Trips;
using Serveur.Models.Entities;

namespace Serveur.Repositories.Interfaces;

public interface ITripRepository
{
    Task<Trip?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Trip?> GetByIdForUpdateAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Trip>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<int> CountByDriverIdAsync(int driverId, CancellationToken cancellationToken = default);
    Task<PagedResultDto<Trip>> GetPagedAsync(TripQueryParamsDto query, CancellationToken cancellationToken = default);
    Task AddAsync(Trip trip, CancellationToken cancellationToken = default);
    Task DeleteAsync(Trip trip, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

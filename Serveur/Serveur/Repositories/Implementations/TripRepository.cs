using Microsoft.EntityFrameworkCore;
using Serveur.Data;
using Serveur.DTOs.Trips;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;

namespace Serveur.Repositories.Implementations;

public class TripRepository : ITripRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TripRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Trip?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        _dbContext.Trips.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public Task<Trip?> GetByIdForUpdateAsync(int id, CancellationToken cancellationToken = default) =>
        _dbContext.Trips.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public async Task<PagedResultDto<Trip>> GetPagedAsync(TripQueryParamsDto query, CancellationToken cancellationToken = default)
    {
        var tripsQuery = _dbContext.Trips.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.City))
        {
            var city = query.City.Trim();
            tripsQuery = tripsQuery.Where(t =>
                t.Departure.Contains(city) || t.Destination.Contains(city));
        }

        if (query.Date.HasValue)
        {
            var date = query.Date.Value.Date;
            tripsQuery = tripsQuery.Where(t => t.Date.Date == date);
        }

        var totalCount = await tripsQuery.CountAsync(cancellationToken);
        var items = await tripsQuery
            .OrderBy(t => t.Date)
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResultDto<Trip>
        {
            Items = items,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            TotalCount = totalCount
        };
    }

    public async Task AddAsync(Trip trip, CancellationToken cancellationToken = default)
    {
        await _dbContext.Trips.AddAsync(trip, cancellationToken);
    }

    public Task DeleteAsync(Trip trip, CancellationToken cancellationToken = default)
    {
        _dbContext.Trips.Remove(trip);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}

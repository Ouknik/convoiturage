using Microsoft.EntityFrameworkCore;
using Serveur.Data;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;

namespace Serveur.Repositories.Implementations;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ReviewRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Review?> GetByPassengerAndTripAsync(int passengerId, int tripId, CancellationToken cancellationToken = default) =>
        _dbContext.Reviews
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.PassengerId == passengerId && r.TripId == tripId, cancellationToken);

    public async Task<IReadOnlyList<Review>> GetByDriverIdAsync(int driverId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Reviews
            .AsNoTracking()
            .Include(r => r.Passenger)
            .Where(r => r.DriverId == driverId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Review review, CancellationToken cancellationToken = default)
    {
        await _dbContext.Reviews.AddAsync(review, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}

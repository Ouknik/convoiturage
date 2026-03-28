using Microsoft.EntityFrameworkCore;
using Serveur.Data;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;

namespace Serveur.Repositories.Implementations;

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ReservationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        _dbContext.Reservations
            .AsNoTracking()
            .Include(r => r.Payment)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public Task<Reservation?> GetByIdForUpdateAsync(int id, CancellationToken cancellationToken = default) =>
        _dbContext.Reservations
            .Include(r => r.Trip)
            .Include(r => r.Payment)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Reservation>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Reservations
            .AsNoTracking()
            .Include(r => r.Payment)
            .OrderByDescending(r => r.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Reservation>> GetAllByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Reservations
            .AsNoTracking()
            .Include(r => r.Payment)
            .Where(r => r.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Reservation>> GetAllByTripIdAsync(int tripId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Reservations
            .AsNoTracking()
            .Include(r => r.Payment)
            .Where(r => r.TripId == tripId)
            .OrderByDescending(r => r.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<int> CountByDriverIdAsync(int driverId, CancellationToken cancellationToken = default) =>
        _dbContext.Reservations
            .AsNoTracking()
            .Include(r => r.Trip)
            .CountAsync(r => r.Trip.DriverId == driverId, cancellationToken);

    public Task<bool> ExistsByUserAndTripAsync(int userId, int tripId, CancellationToken cancellationToken = default) =>
        _dbContext.Reservations.AnyAsync(r => r.UserId == userId && r.TripId == tripId, cancellationToken);

    public async Task AddAsync(Reservation reservation, CancellationToken cancellationToken = default)
    {
        await _dbContext.Reservations.AddAsync(reservation, cancellationToken);
    }

    public Task DeleteAsync(Reservation reservation, CancellationToken cancellationToken = default)
    {
        _dbContext.Reservations.Remove(reservation);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}

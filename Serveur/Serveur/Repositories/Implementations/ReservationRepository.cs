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
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public Task<Reservation?> GetByIdForUpdateAsync(int id, CancellationToken cancellationToken = default) =>
        _dbContext.Reservations
            .Include(r => r.Trip)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Reservation>> GetAllByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Reservations
            .AsNoTracking()
            .Where(r => r.UserId == userId)
            .ToListAsync(cancellationToken);
    }

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

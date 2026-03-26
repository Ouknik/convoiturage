using Microsoft.EntityFrameworkCore;
using Serveur.Data;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;

namespace Serveur.Repositories.Implementations;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AuthorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        _dbContext.Authors
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

    public Task<Author?> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default) =>
        _dbContext.Authors
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.UserId == userId, cancellationToken);

    public async Task AddAsync(Author author, CancellationToken cancellationToken = default)
    {
        await _dbContext.Authors.AddAsync(author, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}

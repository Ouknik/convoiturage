using Serveur.Models.Entities;

namespace Serveur.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Author?> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    Task AddAsync(Author author, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

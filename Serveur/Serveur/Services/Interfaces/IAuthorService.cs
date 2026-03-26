using Serveur.DTOs.Authors;

namespace Serveur.Services.Interfaces;

public interface IAuthorService
{
    Task<AuthorResponseDto> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    Task<AuthorResponseDto> CreateAsync(int currentUserId, AuthorCreateDto request, CancellationToken cancellationToken = default);
    Task<AuthorResponseDto> UpdateAsync(int id, int currentUserId, AuthorUpdateDto request, CancellationToken cancellationToken = default);
}

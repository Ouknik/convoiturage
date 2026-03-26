using Microsoft.AspNetCore.Http;
using Serveur.Common;
using Serveur.DTOs.Authors;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUserRepository _userRepository;

    public AuthorService(IAuthorRepository authorRepository, IUserRepository userRepository)
    {
        _authorRepository = authorRepository;
        _userRepository = userRepository;
    }

    public async Task<AuthorResponseDto> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        var author = await _authorRepository.GetByUserIdAsync(userId, cancellationToken)
            ?? throw new AppException("Author profile not found.", StatusCodes.Status404NotFound);

        return Map(author);
    }

    public async Task<AuthorResponseDto> CreateAsync(int currentUserId, AuthorCreateDto request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(currentUserId, cancellationToken)
            ?? throw new AppException("User not found.", StatusCodes.Status404NotFound);

        var existingAuthor = await _authorRepository.GetByUserIdAsync(currentUserId, cancellationToken);
        if (existingAuthor is not null)
        {
            throw new AppException("Author profile already exists.", StatusCodes.Status409Conflict);
        }

        var author = new Author
        {
            UserId = currentUserId,
            Bio = request.Bio.Trim(),
            Phone = request.Phone.Trim(),
            City = request.City.Trim(),
            ProfileImageUrl = request.ProfileImageUrl.Trim(),
            User = user
        };

        await _authorRepository.AddAsync(author, cancellationToken);
        await _authorRepository.SaveChangesAsync(cancellationToken);

        return Map(author);
    }

    public async Task<AuthorResponseDto> UpdateAsync(int id, int currentUserId, AuthorUpdateDto request, CancellationToken cancellationToken = default)
    {
        var author = await _authorRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new AppException("Author profile not found.", StatusCodes.Status404NotFound);

        if (author.UserId != currentUserId)
        {
            throw new AppException("You can only update your own profile.", StatusCodes.Status403Forbidden);
        }

        author.Bio = request.Bio.Trim();
        author.Phone = request.Phone.Trim();
        author.City = request.City.Trim();
        author.ProfileImageUrl = request.ProfileImageUrl.Trim();

        await _authorRepository.SaveChangesAsync(cancellationToken);

        return Map(author);
    }

    private static AuthorResponseDto Map(Author author) => new()
    {
        Id = author.Id,
        UserId = author.UserId,
        Name = author.User.Name,
        Email = author.User.Email,
        Bio = author.Bio,
        Phone = author.Phone,
        City = author.City,
        ProfileImageUrl = author.ProfileImageUrl
    };
}

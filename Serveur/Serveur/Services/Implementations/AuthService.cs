using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serveur.Common;
using Serveur.DTOs.Auth;
using Serveur.Helpers;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        IUserRepository userRepository,
        IAuthorRepository authorRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher<User> passwordHasher,
        ILogger<AuthService> logger)
    {
        _userRepository = userRepository;
        _authorRepository = authorRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
        _logger = logger;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request, CancellationToken cancellationToken = default)
    {
        if (await _userRepository.EmailExistsAsync(request.Email, cancellationToken))
        {
            throw new AppException("Email already exists.", StatusCodes.Status409Conflict);
        }

        var user = new User
        {
            Name = request.Name.Trim(),
            Email = request.Email.Trim().ToLowerInvariant(),
            Role = request.Role
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        var author = new Author
        {
            UserId = user.Id
        };

        await _authorRepository.AddAsync(author, cancellationToken);
        await _authorRepository.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("New user registered with id {UserId}", user.Id);

        return BuildAuthResponse(user);
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email.Trim().ToLowerInvariant(), cancellationToken)
                   ?? throw new AppException("Invalid credentials.", StatusCodes.Status401Unauthorized);

        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            throw new AppException("Invalid credentials.", StatusCodes.Status401Unauthorized);
        }

        _logger.LogInformation("User {UserId} logged in", user.Id);
        return BuildAuthResponse(user);
    }

    private AuthResponseDto BuildAuthResponse(User user)
    {
        return new AuthResponseDto
        {
            UserId = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role.ToString(),
            Token = _jwtTokenGenerator.GenerateToken(user)
        };
    }
}

using Serveur.DTOs.Drivers;
using Serveur.DTOs.Reviews;

namespace Serveur.Services.Interfaces;

public interface IReviewService
{
    Task<ReviewResponseDto> CreateAsync(int passengerId, ReviewCreateDto request, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReviewResponseDto>> GetByDriverIdAsync(int driverId, CancellationToken cancellationToken = default);
    Task<DriverProfileDto> GetDriverProfileAsync(int driverId, CancellationToken cancellationToken = default);
}

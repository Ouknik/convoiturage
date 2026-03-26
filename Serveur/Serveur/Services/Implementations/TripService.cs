using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serveur.Common;
using Serveur.DTOs.Trips;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<TripService> _logger;

    public TripService(ITripRepository tripRepository, IUserRepository userRepository, ILogger<TripService> logger)
    {
        _tripRepository = tripRepository;
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<PagedResultDto<TripResponseDto>> GetTripsAsync(TripQueryParamsDto query, CancellationToken cancellationToken = default)
    {
        if (query.PageNumber <= 0) query.PageNumber = 1;
        if (query.PageSize <= 0) query.PageSize = 10;

        var pagedTrips = await _tripRepository.GetPagedAsync(query, cancellationToken);

        return new PagedResultDto<TripResponseDto>
        {
            Items = pagedTrips.Items.Select(Map).ToList(),
            PageNumber = pagedTrips.PageNumber,
            PageSize = pagedTrips.PageSize,
            TotalCount = pagedTrips.TotalCount
        };
    }

    public async Task<TripResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var trip = await _tripRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new AppException("Trip not found.", StatusCodes.Status404NotFound);

        return Map(trip);
    }

    public async Task<TripResponseDto> CreateAsync(int driverId, TripCreateDto request, CancellationToken cancellationToken = default)
    {
        var driver = await _userRepository.GetByIdAsync(driverId, cancellationToken)
            ?? throw new AppException("Driver not found.", StatusCodes.Status404NotFound);

        if (driver.Role != UserRole.Driver)
        {
            throw new AppException("Only drivers can create trips.", StatusCodes.Status403Forbidden);
        }

        var trip = new Trip
        {
            Departure = request.Departure.Trim(),
            Destination = request.Destination.Trim(),
            Date = request.Date,
            AvailableSeats = request.AvailableSeats,
            DriverId = driverId
        };

        await _tripRepository.AddAsync(trip, cancellationToken);
        await _tripRepository.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Trip {TripId} created by driver {DriverId}", trip.Id, driverId);

        return Map(trip);
    }

    public async Task DeleteAsync(int id, int userId, CancellationToken cancellationToken = default)
    {
        var trip = await _tripRepository.GetByIdForUpdateAsync(id, cancellationToken)
            ?? throw new AppException("Trip not found.", StatusCodes.Status404NotFound);

        if (trip.DriverId != userId)
        {
            throw new AppException("Only the trip owner can delete this trip.", StatusCodes.Status403Forbidden);
        }

        await _tripRepository.DeleteAsync(trip, cancellationToken);
        await _tripRepository.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Trip {TripId} deleted by user {UserId}", id, userId);
    }

    private static TripResponseDto Map(Trip trip) => new()
    {
        Id = trip.Id,
        Departure = trip.Departure,
        Destination = trip.Destination,
        Date = trip.Date,
        AvailableSeats = trip.AvailableSeats,
        DriverId = trip.DriverId
    };
}

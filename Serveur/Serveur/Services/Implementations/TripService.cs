using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serveur.Common;
using Serveur.DTOs.Reservations;
using Serveur.DTOs.Trips;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Helpers;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<TripService> _logger;

    public TripService(ITripRepository tripRepository, IReservationRepository reservationRepository, IUserRepository userRepository, ILogger<TripService> logger)
    {
        _tripRepository = tripRepository;
        _reservationRepository = reservationRepository;
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
            StartDate = request.StartDate.Date,
            EndDate = request.EndDate.Date,
            StartTime = request.StartTime,
            NumberOfDays = request.NumberOfDays,
            PricePerSeat = request.PricePerSeat,
            DepartureTime = request.StartDate.Date.Add(request.StartTime),
            CreatedAt = DateTime.UtcNow,
            Status = TripStatusResolver.Resolve(request.StartDate.Date.Add(request.StartTime)),
            AvailableSeats = request.AvailableSeats,
            DriverId = driverId
        };

        if (trip.DepartureTime <= DateTime.UtcNow)
        {
            throw new AppException("Cannot create trip in the past.", StatusCodes.Status400BadRequest);
        }

        if (trip.EndDate < trip.StartDate)
        {
            throw new AppException("End date must be after or equal to start date.", StatusCodes.Status400BadRequest);
        }

        if (trip.AvailableSeats <= 0)
        {
            throw new AppException("Available seats must be greater than 0.", StatusCodes.Status400BadRequest);
        }

        if (trip.PricePerSeat <= 0)
        {
            throw new AppException("Price per seat must be greater than 0.", StatusCodes.Status400BadRequest);
        }

        var expectedDays = (trip.EndDate.Date - trip.StartDate.Date).Days + 1;
        trip.NumberOfDays = expectedDays;

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

    public async Task<IReadOnlyList<ReservationResponseDto>> GetTripReservationsAsync(int tripId, int currentUserId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(currentUserId, cancellationToken)
            ?? throw new AppException("User not found.", StatusCodes.Status404NotFound);

        var trip = await _tripRepository.GetByIdAsync(tripId, cancellationToken)
            ?? throw new AppException("Trip not found.", StatusCodes.Status404NotFound);

        var isAdmin = user.Role == UserRole.Admin;
        var isOwnerDriver = user.Role == UserRole.Driver && trip.DriverId == currentUserId;

        if (!isAdmin && !isOwnerDriver)
        {
            throw new AppException("Only trip owner driver or admin can view trip reservations.", StatusCodes.Status403Forbidden);
        }

        var reservations = await _reservationRepository.GetAllByTripIdAsync(tripId, cancellationToken);

        return reservations.Select(r => new ReservationResponseDto
        {
            Id = r.Id,
            TripId = r.TripId,
            UserId = r.UserId,
            SeatsReserved = r.SeatsReserved,
            PaymentId = r.Payment?.Id ?? 0,
            PaymentAmount = r.Payment?.Amount ?? 0,
            PaymentMethod = r.Payment?.Method.ToString() ?? string.Empty,
            PaymentStatus = r.Payment?.Status.ToString() ?? string.Empty
        }).ToList();
    }

    private static TripResponseDto Map(Trip trip) => new()
    {
        Id = trip.Id,
        Departure = trip.Departure,
        Destination = trip.Destination,
        DepartureTime = trip.DepartureTime,
        StartDate = trip.StartDate,
        EndDate = trip.EndDate,
        StartTime = trip.StartTime,
        NumberOfDays = trip.NumberOfDays,
        PricePerSeat = trip.PricePerSeat,
        CreatedAt = trip.CreatedAt,
        Status = TripStatusResolver.Resolve(trip.DepartureTime).ToString(),
        AvailableSeats = trip.AvailableSeats,
        DriverId = trip.DriverId
    };
}

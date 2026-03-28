using Microsoft.AspNetCore.Http;
using Serveur.Common;
using Serveur.DTOs.Drivers;
using Serveur.DTOs.Reviews;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Helpers;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly ITripRepository _tripRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthorRepository _authorRepository;

    public ReviewService(
        IReviewRepository reviewRepository,
        ITripRepository tripRepository,
        IReservationRepository reservationRepository,
        IUserRepository userRepository,
        IAuthorRepository authorRepository)
    {
        _reviewRepository = reviewRepository;
        _tripRepository = tripRepository;
        _reservationRepository = reservationRepository;
        _userRepository = userRepository;
        _authorRepository = authorRepository;
    }

    public async Task<ReviewResponseDto> CreateAsync(int passengerId, ReviewCreateDto request, CancellationToken cancellationToken = default)
    {
        var passenger = await _userRepository.GetByIdAsync(passengerId, cancellationToken)
            ?? throw new AppException("Passenger not found.", StatusCodes.Status404NotFound);

        if (passenger.Role != UserRole.Passenger)
        {
            throw new AppException("Only passengers can leave reviews.", StatusCodes.Status403Forbidden);
        }

        var trip = await _tripRepository.GetByIdAsync(request.TripId, cancellationToken)
            ?? throw new AppException("Trip not found.", StatusCodes.Status404NotFound);

        var tripStatus = TripStatusResolver.Resolve(trip.DepartureTime);
        if (tripStatus != TripStatus.Completed)
        {
            throw new AppException("Review is allowed only after trip completion.", StatusCodes.Status400BadRequest);
        }

        var hasReservation = await _reservationRepository.ExistsByUserAndTripAsync(passengerId, request.TripId, cancellationToken);
        if (!hasReservation)
        {
            throw new AppException("You can only review drivers for trips you reserved.", StatusCodes.Status403Forbidden);
        }

        var existingReview = await _reviewRepository.GetByPassengerAndTripAsync(passengerId, request.TripId, cancellationToken);
        if (existingReview is not null)
        {
            throw new AppException("You already reviewed this trip.", StatusCodes.Status409Conflict);
        }

        var review = new Review
        {
            DriverId = trip.DriverId,
            PassengerId = passengerId,
            TripId = request.TripId,
            Rating = request.Rating,
            Comment = request.Comment?.Trim() ?? string.Empty,
            CreatedAt = DateTime.UtcNow
        };

        await _reviewRepository.AddAsync(review, cancellationToken);
        await _reviewRepository.SaveChangesAsync(cancellationToken);

        return new ReviewResponseDto
        {
            Id = review.Id,
            DriverId = review.DriverId,
            PassengerId = review.PassengerId,
            TripId = review.TripId,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt,
            PassengerName = passenger.Name
        };
    }

    public async Task<IReadOnlyList<ReviewResponseDto>> GetByDriverIdAsync(int driverId, CancellationToken cancellationToken = default)
    {
        var driver = await _userRepository.GetByIdAsync(driverId, cancellationToken)
            ?? throw new AppException("Driver not found.", StatusCodes.Status404NotFound);

        var reviews = await _reviewRepository.GetByDriverIdAsync(driverId, cancellationToken);

        return reviews.Select(r => new ReviewResponseDto
        {
            Id = r.Id,
            DriverId = r.DriverId,
            PassengerId = r.PassengerId,
            TripId = r.TripId,
            Rating = r.Rating,
            Comment = r.Comment,
            CreatedAt = r.CreatedAt,
            PassengerName = r.Passenger?.Name ?? string.Empty
        }).ToList();
    }

    public async Task<DriverProfileDto> GetDriverProfileAsync(int driverId, CancellationToken cancellationToken = default)
    {
        var driver = await _userRepository.GetByIdAsync(driverId, cancellationToken)
            ?? throw new AppException("Driver not found.", StatusCodes.Status404NotFound);

        var author = await _authorRepository.GetByUserIdAsync(driverId, cancellationToken);

        var totalTrips = await _tripRepository.CountByDriverIdAsync(driverId, cancellationToken);
        var totalReservations = await _reservationRepository.CountByDriverIdAsync(driverId, cancellationToken);

        var reviews = await _reviewRepository.GetByDriverIdAsync(driverId, cancellationToken);
        var reviewDtos = reviews.Select(r => new ReviewResponseDto
        {
            Id = r.Id,
            DriverId = r.DriverId,
            PassengerId = r.PassengerId,
            TripId = r.TripId,
            Rating = r.Rating,
            Comment = r.Comment,
            CreatedAt = r.CreatedAt,
            PassengerName = r.Passenger?.Name ?? string.Empty
        }).ToList();

        var totalReviews = reviewDtos.Count;
        var averageRating = totalReviews == 0 ? 0 : Math.Round(reviewDtos.Average(r => r.Rating), 2);

        return new DriverProfileDto
        {
            DriverId = driver.Id,
            Name = driver.Name,
            Email = driver.Email,
            City = author?.City ?? string.Empty,
            Bio = author?.Bio ?? string.Empty,
            TotalTripsCreated = totalTrips,
            TotalReservationsReceived = totalReservations,
            AverageRating = averageRating,
            TotalReviews = totalReviews,
            Reviews = reviewDtos
        };
    }
}

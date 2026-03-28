using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serveur.Common;
using Serveur.Data;
using Serveur.DTOs.Reservations;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Helpers;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ITripRepository _tripRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<ReservationService> _logger;

    public ReservationService(
        IReservationRepository reservationRepository,
        ITripRepository tripRepository,
        IUserRepository userRepository,
        IPaymentRepository paymentRepository,
        ApplicationDbContext dbContext,
        ILogger<ReservationService> logger)
    {
        _reservationRepository = reservationRepository;
        _tripRepository = tripRepository;
        _userRepository = userRepository;
        _paymentRepository = paymentRepository;
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<ReservationResponseDto> CreateAsync(int userId, ReservationCreateDto request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken)
            ?? throw new AppException("User not found.", StatusCodes.Status404NotFound);

        if (user.Role != UserRole.Passenger)
        {
            throw new AppException("Only passengers can reserve seats.", StatusCodes.Status403Forbidden);
        }

        var trip = await _tripRepository.GetByIdForUpdateAsync(request.TripId, cancellationToken)
            ?? throw new AppException("Trip not found.", StatusCodes.Status404NotFound);

        var tripStatus = TripStatusResolver.Resolve(trip.DepartureTime);
        if (tripStatus == TripStatus.Completed)
        {
            throw new AppException("Cannot reserve completed trips.", StatusCodes.Status400BadRequest);
        }

        if (await _reservationRepository.ExistsByUserAndTripAsync(userId, request.TripId, cancellationToken))
        {
            throw new AppException("Duplicate reservation is not allowed.", StatusCodes.Status409Conflict);
        }

        if (trip.AvailableSeats < request.Seats)
        {
            throw new AppException("Not enough available seats.", StatusCodes.Status400BadRequest);
        }

        if (!Enum.TryParse<PaymentMethod>(request.PaymentMethod, true, out var paymentMethod))
        {
            throw new AppException("Invalid payment method.", StatusCodes.Status400BadRequest);
        }

        if (paymentMethod == PaymentMethod.Card)
        {
            if (string.IsNullOrWhiteSpace(request.CardHolderName)
                || string.IsNullOrWhiteSpace(request.CardNumber)
                || string.IsNullOrWhiteSpace(request.ExpiryDate)
                || string.IsNullOrWhiteSpace(request.Cvv))
            {
                throw new AppException("Card details are required for card payment.", StatusCodes.Status400BadRequest);
            }
        }

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        trip.AvailableSeats -= request.Seats;
        trip.Status = TripStatusResolver.Resolve(trip.DepartureTime);

        var reservation = new Reservation
        {
            TripId = request.TripId,
            UserId = userId,
            SeatsReserved = request.Seats
        };

        var payment = new Payment
        {
            Reservation = reservation,
            Amount = request.Seats * trip.PricePerSeat,
            Method = paymentMethod,
            Status = paymentMethod == PaymentMethod.Cash ? PaymentStatus.Pending : PaymentStatus.Paid,
            CardHolderName = paymentMethod == PaymentMethod.Card ? request.CardHolderName?.Trim() : null,
            CardNumber = paymentMethod == PaymentMethod.Card ? request.CardNumber?.Trim() : null,
            ExpiryDate = paymentMethod == PaymentMethod.Card ? request.ExpiryDate?.Trim() : null,
            Cvv = paymentMethod == PaymentMethod.Card ? request.Cvv?.Trim() : null,
            CreatedAt = DateTime.UtcNow
        };

        reservation.Payment = payment;

        await _reservationRepository.AddAsync(reservation, cancellationToken);
        await _paymentRepository.AddAsync(payment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        _logger.LogInformation("Reservation {ReservationId} created for trip {TripId} by user {UserId}", reservation.Id, trip.Id, userId);

        return Map(reservation);
    }

    public async Task<IReadOnlyList<ReservationResponseDto>> GetUserReservationsAsync(int userId, CancellationToken cancellationToken = default)
    {
        var reservations = await _reservationRepository.GetAllByUserIdAsync(userId, cancellationToken);
        return reservations.Select(Map).ToList();
    }

    public async Task DeleteAsync(int id, int userId, CancellationToken cancellationToken = default)
    {
        var reservation = await _reservationRepository.GetByIdForUpdateAsync(id, cancellationToken)
            ?? throw new AppException("Reservation not found.", StatusCodes.Status404NotFound);

        if (reservation.UserId != userId)
        {
            throw new AppException("Only reservation owner can delete it.", StatusCodes.Status403Forbidden);
        }

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        reservation.Trip.AvailableSeats += reservation.SeatsReserved;
        reservation.Trip.Status = TripStatusResolver.Resolve(reservation.Trip.DepartureTime);
        await _reservationRepository.DeleteAsync(reservation, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        _logger.LogInformation("Reservation {ReservationId} deleted by user {UserId}", id, userId);
    }

    private static ReservationResponseDto Map(Reservation reservation) => new()
    {
        Id = reservation.Id,
        TripId = reservation.TripId,
        UserId = reservation.UserId,
        SeatsReserved = reservation.SeatsReserved,
        PaymentId = reservation.Payment?.Id ?? 0,
        PaymentAmount = reservation.Payment?.Amount ?? 0,
        PaymentMethod = reservation.Payment?.Method.ToString() ?? string.Empty,
        PaymentStatus = reservation.Payment?.Status.ToString() ?? string.Empty
    };
}

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serveur.Common;
using Serveur.Data;
using Serveur.DTOs.Reservations;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ITripRepository _tripRepository;
    private readonly IUserRepository _userRepository;
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<ReservationService> _logger;

    public ReservationService(
        IReservationRepository reservationRepository,
        ITripRepository tripRepository,
        IUserRepository userRepository,
        ApplicationDbContext dbContext,
        ILogger<ReservationService> logger)
    {
        _reservationRepository = reservationRepository;
        _tripRepository = tripRepository;
        _userRepository = userRepository;
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

        if (trip.AvailableSeats < request.SeatsReserved)
        {
            throw new AppException("Not enough available seats.", StatusCodes.Status400BadRequest);
        }

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        trip.AvailableSeats -= request.SeatsReserved;

        var reservation = new Reservation
        {
            TripId = request.TripId,
            UserId = userId,
            SeatsReserved = request.SeatsReserved
        };

        await _reservationRepository.AddAsync(reservation, cancellationToken);
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
        SeatsReserved = reservation.SeatsReserved
    };
}

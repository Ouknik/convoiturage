using Microsoft.AspNetCore.Http;
using Serveur.Common;
using Serveur.DTOs.Admin;
using Serveur.DTOs.Payments;
using Serveur.DTOs.Trips;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Helpers;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly ITripRepository _tripRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IPaymentRepository _paymentRepository;

    public AdminService(
        IUserRepository userRepository,
        ITripRepository tripRepository,
        IReservationRepository reservationRepository,
        IPaymentRepository paymentRepository)
    {
        _userRepository = userRepository;
        _tripRepository = tripRepository;
        _reservationRepository = reservationRepository;
        _paymentRepository = paymentRepository;
    }

    public async Task<IReadOnlyList<AdminUserDto>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return users.Select(u => new AdminUserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Role = u.Role.ToString()
        }).ToList();
    }

    public async Task<IReadOnlyList<TripResponseDto>> GetTripsAsync(CancellationToken cancellationToken = default)
    {
        var trips = await _tripRepository.GetAllAsync(cancellationToken);
        return trips.Select(t => new TripResponseDto
        {
            Id = t.Id,
            Departure = t.Departure,
            Destination = t.Destination,
            DepartureTime = t.DepartureTime,
            CreatedAt = t.CreatedAt,
            Status = TripStatusResolver.Resolve(t.DepartureTime).ToString(),
            AvailableSeats = t.AvailableSeats,
            DriverId = t.DriverId
        }).ToList();
    }

    public async Task<IReadOnlyList<AdminReservationDto>> GetReservationsAsync(CancellationToken cancellationToken = default)
    {
        var reservations = await _reservationRepository.GetAllAsync(cancellationToken);
        return reservations.Select(r => new AdminReservationDto
        {
            Id = r.Id,
            TripId = r.TripId,
            UserId = r.UserId,
            SeatsReserved = r.SeatsReserved,
            PaymentMethod = r.Payment?.Method.ToString() ?? string.Empty,
            PaymentStatus = r.Payment?.Status.ToString() ?? string.Empty
        }).ToList();
    }

    public async Task<IReadOnlyList<PaymentResponseDto>> GetPaymentsAsync(CancellationToken cancellationToken = default)
    {
        var payments = await _paymentRepository.GetAllAsync(cancellationToken);
        return payments.Select(p => new PaymentResponseDto
        {
            Id = p.Id,
            ReservationId = p.ReservationId,
            Amount = p.Amount,
            Method = p.Method.ToString(),
            Status = p.Status.ToString(),
            CreatedAt = p.CreatedAt
        }).ToList();
    }

    public async Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new AppException("User not found.", StatusCodes.Status404NotFound);

        await _userRepository.DeleteAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteTripAsync(int id, CancellationToken cancellationToken = default)
    {
        var trip = await _tripRepository.GetByIdForUpdateAsync(id, cancellationToken)
            ?? throw new AppException("Trip not found.", StatusCodes.Status404NotFound);

        await _tripRepository.DeleteAsync(trip, cancellationToken);
        await _tripRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteReservationAsync(int id, CancellationToken cancellationToken = default)
    {
        var reservation = await _reservationRepository.GetByIdForUpdateAsync(id, cancellationToken)
            ?? throw new AppException("Reservation not found.", StatusCodes.Status404NotFound);

        reservation.Trip.AvailableSeats += reservation.SeatsReserved;
        await _reservationRepository.DeleteAsync(reservation, cancellationToken);
        await _reservationRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePaymentAsync(int id, CancellationToken cancellationToken = default)
    {
        var payment = await _paymentRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new AppException("Payment not found.", StatusCodes.Status404NotFound);

        await _paymentRepository.DeleteAsync(payment, cancellationToken);
        await _paymentRepository.SaveChangesAsync(cancellationToken);
    }
}

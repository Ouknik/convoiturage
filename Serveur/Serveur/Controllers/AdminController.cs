using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serveur.Common;
using Serveur.DTOs.Admin;
using Serveur.DTOs.Payments;
using Serveur.DTOs.Trips;
using Serveur.Services.Interfaces;

namespace Serveur.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var result = await _adminService.GetUsersAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<AdminUserDto>>.Ok(result, "Users retrieved successfully."));
    }

    [HttpGet("trips")]
    public async Task<IActionResult> GetTrips(CancellationToken cancellationToken)
    {
        var result = await _adminService.GetTripsAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<TripResponseDto>>.Ok(result, "Trips retrieved successfully."));
    }

    [HttpGet("reservations")]
    public async Task<IActionResult> GetReservations(CancellationToken cancellationToken)
    {
        var result = await _adminService.GetReservationsAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<AdminReservationDto>>.Ok(result, "Reservations retrieved successfully."));
    }

    [HttpGet("payments")]
    public async Task<IActionResult> GetPayments(CancellationToken cancellationToken)
    {
        var result = await _adminService.GetPaymentsAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<PaymentResponseDto>>.Ok(result, "Payments retrieved successfully."));
    }

    [HttpDelete("users/{id:int}")]
    public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
    {
        await _adminService.DeleteUserAsync(id, cancellationToken);
        return Ok(ApiResponse<object>.Ok(null, "User deleted successfully."));
    }

    [HttpDelete("trips/{id:int}")]
    public async Task<IActionResult> DeleteTrip(int id, CancellationToken cancellationToken)
    {
        await _adminService.DeleteTripAsync(id, cancellationToken);
        return Ok(ApiResponse<object>.Ok(null, "Trip deleted successfully."));
    }

    [HttpDelete("reservations/{id:int}")]
    public async Task<IActionResult> DeleteReservation(int id, CancellationToken cancellationToken)
    {
        await _adminService.DeleteReservationAsync(id, cancellationToken);
        return Ok(ApiResponse<object>.Ok(null, "Reservation deleted successfully."));
    }

    [HttpDelete("payments/{id:int}")]
    public async Task<IActionResult> DeletePayment(int id, CancellationToken cancellationToken)
    {
        await _adminService.DeletePaymentAsync(id, cancellationToken);
        return Ok(ApiResponse<object>.Ok(null, "Payment deleted successfully."));
    }
}

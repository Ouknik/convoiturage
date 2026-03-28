using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serveur.Common;
using Serveur.DTOs.Reservations;
using Serveur.Helpers;
using Serveur.Services.Interfaces;

namespace Serveur.Controllers;

[Authorize(Roles = "Passenger")]
[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReservationCreateDto request, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var result = await _reservationService.CreateAsync(userId, request, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, ApiResponse<ReservationResponseDto>.Ok(result, "Reservation created successfully."));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var result = await _reservationService.GetUserReservationsAsync(userId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<ReservationResponseDto>>.Ok(result, "Reservations retrieved successfully."));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        await _reservationService.DeleteAsync(id, userId, cancellationToken);
        return Ok(ApiResponse<object>.Ok(null, "Reservation deleted successfully."));
    }
}

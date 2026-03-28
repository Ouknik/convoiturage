using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serveur.Common;
using Serveur.DTOs.Reservations;
using Serveur.DTOs.Trips;
using Serveur.Helpers;
using Serveur.Services.Interfaces;

namespace Serveur.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips([FromQuery] TripQueryParamsDto query, CancellationToken cancellationToken)
    {
        var result = await _tripService.GetTripsAsync(query, cancellationToken);
        return Ok(ApiResponse<PagedResultDto<TripResponseDto>>.Ok(result, "Trips retrieved successfully."));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _tripService.GetByIdAsync(id, cancellationToken);
        return Ok(ApiResponse<TripResponseDto>.Ok(result, "Trip retrieved successfully."));
    }

    [Authorize(Roles = "Driver,Admin")]
    [HttpGet("{id:int}/reservations")]
    public async Task<IActionResult> GetTripReservations(int id, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var result = await _tripService.GetTripReservationsAsync(id, userId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<ReservationResponseDto>>.Ok(result, "Trip reservations retrieved successfully."));
    }

    [Authorize(Roles = "Driver")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TripCreateDto request, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var result = await _tripService.CreateAsync(userId, request, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, ApiResponse<TripResponseDto>.Ok(result, "Trip created successfully."));
    }

    [Authorize(Roles = "Driver")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        await _tripService.DeleteAsync(id, userId, cancellationToken);
        return Ok(ApiResponse<object>.Ok(null, "Trip deleted successfully."));
    }
}

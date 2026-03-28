using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serveur.Common;
using Serveur.DTOs.Reviews;
using Serveur.Helpers;
using Serveur.Services.Interfaces;

namespace Serveur.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [Authorize(Roles = "Passenger")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReviewCreateDto request, CancellationToken cancellationToken)
    {
        var passengerId = User.GetUserId();
        var result = await _reviewService.CreateAsync(passengerId, request, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, ApiResponse<ReviewResponseDto>.Ok(result, "Review submitted successfully."));
    }

    [HttpGet("driver/{driverId:int}")]
    public async Task<IActionResult> GetByDriver(int driverId, CancellationToken cancellationToken)
    {
        var result = await _reviewService.GetByDriverIdAsync(driverId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<ReviewResponseDto>>.Ok(result, "Driver reviews retrieved successfully."));
    }
}

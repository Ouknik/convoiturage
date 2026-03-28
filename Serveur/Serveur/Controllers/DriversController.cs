using Microsoft.AspNetCore.Mvc;
using Serveur.Common;
using Serveur.DTOs.Drivers;
using Serveur.Services.Interfaces;

namespace Serveur.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public DriversController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("{id:int}/profile")]
    public async Task<IActionResult> GetProfile(int id, CancellationToken cancellationToken)
    {
        var result = await _reviewService.GetDriverProfileAsync(id, cancellationToken);
        return Ok(ApiResponse<DriverProfileDto>.Ok(result, "Driver profile retrieved successfully."));
    }
}

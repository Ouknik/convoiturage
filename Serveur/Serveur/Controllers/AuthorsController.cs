using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serveur.Common;
using Serveur.DTOs.Authors;
using Serveur.Helpers;
using Serveur.Services.Interfaces;

namespace Serveur.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetByUserId(int userId, CancellationToken cancellationToken)
    {
        var result = await _authorService.GetByUserIdAsync(userId, cancellationToken);
        return Ok(ApiResponse<AuthorResponseDto>.Ok(result, "Author profile retrieved successfully."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorCreateDto request, CancellationToken cancellationToken)
    {
        var currentUserId = User.GetUserId();
        var result = await _authorService.CreateAsync(currentUserId, request, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, ApiResponse<AuthorResponseDto>.Ok(result, "Author profile created successfully."));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] AuthorUpdateDto request, CancellationToken cancellationToken)
    {
        var currentUserId = User.GetUserId();
        var result = await _authorService.UpdateAsync(id, currentUserId, request, cancellationToken);
        return Ok(ApiResponse<AuthorResponseDto>.Ok(result, "Author profile updated successfully."));
    }
}

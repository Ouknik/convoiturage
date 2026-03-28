using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serveur.Common;
using Serveur.DTOs.Payments;
using Serveur.Services.Interfaces;

namespace Serveur.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _paymentService.GetAllAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<PaymentResponseDto>>.Ok(result, "Payments retrieved successfully."));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _paymentService.GetByIdAsync(id, cancellationToken);
        return Ok(ApiResponse<PaymentResponseDto>.Ok(result, "Payment retrieved successfully."));
    }

    [HttpPut("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] PaymentStatusUpdateDto request, CancellationToken cancellationToken)
    {
        var result = await _paymentService.UpdateStatusAsync(id, request, cancellationToken);
        return Ok(ApiResponse<PaymentResponseDto>.Ok(result, "Payment status updated successfully."));
    }
}

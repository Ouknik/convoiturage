using Microsoft.AspNetCore.Http;
using Serveur.Common;
using Serveur.DTOs.Payments;
using Serveur.Models.Entities;
using Serveur.Repositories.Interfaces;
using Serveur.Services.Interfaces;

namespace Serveur.Services.Implementations;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<IReadOnlyList<PaymentResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var payments = await _paymentRepository.GetAllAsync(cancellationToken);
        return payments.Select(Map).ToList();
    }

    public async Task<PaymentResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var payment = await _paymentRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new AppException("Payment not found.", StatusCodes.Status404NotFound);

        return Map(payment);
    }

    public async Task<PaymentResponseDto> UpdateStatusAsync(int id, PaymentStatusUpdateDto request, CancellationToken cancellationToken = default)
    {
        if (!Enum.TryParse<PaymentStatus>(request.Status, true, out var parsedStatus))
        {
            throw new AppException("Invalid payment status.", StatusCodes.Status400BadRequest);
        }

        var payment = await _paymentRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new AppException("Payment not found.", StatusCodes.Status404NotFound);

        payment.Status = parsedStatus;
        await _paymentRepository.SaveChangesAsync(cancellationToken);

        return Map(payment);
    }

    private static PaymentResponseDto Map(Payment payment) => new()
    {
        Id = payment.Id,
        ReservationId = payment.ReservationId,
        Amount = payment.Amount,
        Method = payment.Method.ToString(),
        Status = payment.Status.ToString(),
        CreatedAt = payment.CreatedAt
    };
}

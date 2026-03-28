using Serveur.DTOs.Payments;

namespace Serveur.Services.Interfaces;

public interface IPaymentService
{
    Task<IReadOnlyList<PaymentResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PaymentResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PaymentResponseDto> UpdateStatusAsync(int id, PaymentStatusUpdateDto request, CancellationToken cancellationToken = default);
}

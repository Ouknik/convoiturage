using System.ComponentModel.DataAnnotations;

namespace Serveur.DTOs.Payments;

public class PaymentStatusUpdateDto
{
    [Required]
    public string Status { get; set; } = string.Empty;
}

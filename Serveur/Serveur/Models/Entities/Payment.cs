using System.ComponentModel.DataAnnotations;

namespace Serveur.Models.Entities;

public class Payment
{
    public int Id { get; set; }

    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; } = null!;

    [Range(0.01, 999999)]
    public decimal Amount { get; set; }

    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }

    [MaxLength(120)]
    public string? CardHolderName { get; set; }

    [MaxLength(32)]
    public string? CardNumber { get; set; }

    [MaxLength(10)]
    public string? ExpiryDate { get; set; }

    [MaxLength(10)]
    public string? Cvv { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

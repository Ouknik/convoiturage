using System.ComponentModel.DataAnnotations;

namespace Serveur.DTOs.Reservations;

public class ReservationCreateDto
{
    [Required]
    public int TripId { get; set; }

    [Range(1, 8)]
    public int Seats { get; set; }

    [Required]
    public string PaymentMethod { get; set; } = string.Empty;

    public string? CardHolderName { get; set; }
    public string? CardNumber { get; set; }
    public string? ExpiryDate { get; set; }
    public string? Cvv { get; set; }
}

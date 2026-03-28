namespace Serveur.DTOs.Reservations;

public class ReservationResponseDto
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public int UserId { get; set; }
    public int SeatsReserved { get; set; }
    public int PaymentId { get; set; }
    public decimal PaymentAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string PaymentStatus { get; set; } = string.Empty;
}

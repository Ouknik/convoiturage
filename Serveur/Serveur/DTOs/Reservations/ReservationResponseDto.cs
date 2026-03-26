namespace Serveur.DTOs.Reservations;

public class ReservationResponseDto
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public int UserId { get; set; }
    public int SeatsReserved { get; set; }
}

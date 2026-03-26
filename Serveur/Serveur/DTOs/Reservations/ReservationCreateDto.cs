using System.ComponentModel.DataAnnotations;

namespace Serveur.DTOs.Reservations;

public class ReservationCreateDto
{
    [Required]
    public int TripId { get; set; }

    [Range(1, 8)]
    public int SeatsReserved { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Serveur.DTOs.Trips;

public class TripCreateDto
{
    [Required, MaxLength(100)]
    public string Departure { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Destination { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    [Range(1, 8)]
    public int AvailableSeats { get; set; }
}

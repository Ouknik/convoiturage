using System.ComponentModel.DataAnnotations;

namespace Serveur.DTOs.Trips;

public class TripCreateDto
{
    [Required, MaxLength(100)]
    public string Departure { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Destination { get; set; } = string.Empty;

    [Required]
    public DateTime DepartureTime { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Range(1, 3650)]
    public int NumberOfDays { get; set; }

    [Range(0.01, 999999)]
    public decimal PricePerSeat { get; set; }

    [Range(1, 8)]
    public int AvailableSeats { get; set; }
}

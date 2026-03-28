using System.ComponentModel.DataAnnotations;

namespace Serveur.Models.Entities;

public class Trip
{
    public int Id { get; set; }

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

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public TripStatus Status { get; set; } = TripStatus.Upcoming;

    [Range(0, 8)]
    public int AvailableSeats { get; set; }

    public int DriverId { get; set; }
    public User Driver { get; set; } = null!;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}

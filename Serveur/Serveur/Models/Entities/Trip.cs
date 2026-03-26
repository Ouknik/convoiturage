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
    public DateTime Date { get; set; }

    [Range(0, 8)]
    public int AvailableSeats { get; set; }

    public int DriverId { get; set; }
    public User Driver { get; set; } = null!;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

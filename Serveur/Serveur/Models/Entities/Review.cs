using System.ComponentModel.DataAnnotations;

namespace Serveur.Models.Entities;

public class Review
{
    public int Id { get; set; }

    public int DriverId { get; set; }
    public User Driver { get; set; } = null!;

    public int PassengerId { get; set; }
    public User Passenger { get; set; } = null!;

    public int TripId { get; set; }
    public Trip Trip { get; set; } = null!;

    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(2000)]
    public string Comment { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

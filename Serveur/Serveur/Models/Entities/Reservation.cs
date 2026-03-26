using System.ComponentModel.DataAnnotations;

namespace Serveur.Models.Entities;

public class Reservation
{
    public int Id { get; set; }

    public int TripId { get; set; }
    public Trip Trip { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Range(1, 8)]
    public int SeatsReserved { get; set; }
}

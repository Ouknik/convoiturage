namespace Serveur.DTOs.Trips;

public class TripResponseDto
{
    public int Id { get; set; }
    public string Departure { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int AvailableSeats { get; set; }
    public int DriverId { get; set; }
}

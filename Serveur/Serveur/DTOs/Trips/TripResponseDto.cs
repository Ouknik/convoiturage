namespace Serveur.DTOs.Trips;

public class TripResponseDto
{
    public int Id { get; set; }
    public string Departure { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public int NumberOfDays { get; set; }
    public decimal PricePerSeat { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public int AvailableSeats { get; set; }
    public int DriverId { get; set; }
}

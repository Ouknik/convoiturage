namespace Serveur.DTOs.Reviews;

public class ReviewResponseDto
{
    public int Id { get; set; }
    public int DriverId { get; set; }
    public int PassengerId { get; set; }
    public int TripId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string PassengerName { get; set; } = string.Empty;
}

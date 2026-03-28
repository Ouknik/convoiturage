using Serveur.DTOs.Reviews;

namespace Serveur.DTOs.Drivers;

public class DriverProfileDto
{
    public int DriverId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public int TotalTripsCreated { get; set; }
    public int TotalReservationsReceived { get; set; }
    public double AverageRating { get; set; }
    public int TotalReviews { get; set; }
    public IReadOnlyList<ReviewResponseDto> Reviews { get; set; } = Array.Empty<ReviewResponseDto>();
}

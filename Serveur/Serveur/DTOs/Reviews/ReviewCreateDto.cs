using System.ComponentModel.DataAnnotations;

namespace Serveur.DTOs.Reviews;

public class ReviewCreateDto
{
    [Required]
    public int TripId { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(2000)]
    public string Comment { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;

namespace Serveur.DTOs.Authors;

public class AuthorCreateDto
{
    [MaxLength(1000)]
    public string Bio { get; set; } = string.Empty;

    [MaxLength(30)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [MaxLength(500)]
    public string ProfileImageUrl { get; set; } = string.Empty;
}

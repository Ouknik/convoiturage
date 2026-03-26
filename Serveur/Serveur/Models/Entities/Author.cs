using System.ComponentModel.DataAnnotations;

namespace Serveur.Models.Entities;

public class Author
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [MaxLength(1000)]
    public string Bio { get; set; } = string.Empty;

    [MaxLength(30)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [MaxLength(500)]
    public string ProfileImageUrl { get; set; } = string.Empty;
}

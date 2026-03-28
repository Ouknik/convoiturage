using System.Collections.Generic;

namespace Serveur.DTOs.Authors;

public class AuthorResponseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ProfileImageUrl { get; set; } = string.Empty;
    public List<SavedCardDto> SavedCards { get; set; } = new();
}

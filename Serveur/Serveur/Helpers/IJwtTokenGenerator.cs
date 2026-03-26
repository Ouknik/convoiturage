using Serveur.Models.Entities;

namespace Serveur.Helpers;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

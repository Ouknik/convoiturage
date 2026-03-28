using System.Security.Claims;
using Serveur.Common;

namespace Serveur.Helpers;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal principal)
    {
        var claimValue = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(claimValue, out var userId))
        {
            throw new AppException("Invalid user token.", StatusCodes.Status401Unauthorized);
        }

        return userId;
    }

    public static string GetUserRole(this ClaimsPrincipal principal)
    {
        var role = principal.FindFirstValue(ClaimTypes.Role);
        if (string.IsNullOrWhiteSpace(role))
        {
            throw new AppException("Invalid user role in token.", StatusCodes.Status401Unauthorized);
        }

        return role;
    }
}

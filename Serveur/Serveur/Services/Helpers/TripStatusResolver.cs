using Serveur.Models.Entities;

namespace Serveur.Services.Helpers;

public static class TripStatusResolver
{
    public static TripStatus Resolve(DateTime departureTimeUtc)
    {
        var now = DateTime.UtcNow;

        if (now < departureTimeUtc)
        {
            return TripStatus.Upcoming;
        }

        if (now <= departureTimeUtc.AddHours(2))
        {
            return TripStatus.Ongoing;
        }

        return TripStatus.Completed;
    }
}

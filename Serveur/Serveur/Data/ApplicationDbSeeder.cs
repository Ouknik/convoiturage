using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serveur.Models.Entities;

namespace Serveur.Data;

public static class ApplicationDbSeeder
{
    public static async Task SeedDemoDataAsync(
        ApplicationDbContext dbContext,
        IPasswordHasher<User> passwordHasher,
        string adminName,
        string adminEmail,
        string adminPassword,
        CancellationToken cancellationToken = default)
    {
        var admin = await GetOrCreateUserAsync(dbContext, passwordHasher, adminName, adminEmail, UserRole.Admin, adminPassword, cancellationToken);
        var driver1 = await GetOrCreateUserAsync(dbContext, passwordHasher, "Youssef Driver", "driver1@demo.local", UserRole.Driver, "123456", cancellationToken);
        var driver2 = await GetOrCreateUserAsync(dbContext, passwordHasher, "Nadia Driver", "driver2@demo.local", UserRole.Driver, "123456", cancellationToken);
        var passenger1 = await GetOrCreateUserAsync(dbContext, passwordHasher, "Salma Passenger", "passenger1@demo.local", UserRole.Passenger, "123456", cancellationToken);
        var passenger2 = await GetOrCreateUserAsync(dbContext, passwordHasher, "Karim Passenger", "passenger2@demo.local", UserRole.Passenger, "123456", cancellationToken);
        var passenger3 = await GetOrCreateUserAsync(dbContext, passwordHasher, "Hassan Passenger", "passenger3@demo.local", UserRole.Passenger, "123456", cancellationToken);

        await EnsureAuthorAsync(dbContext, admin.Id, "System super admin profile", "+212600000001", "Casablanca", cancellationToken);
        await EnsureAuthorAsync(dbContext, driver1.Id, "Experienced intercity driver.", "+212600000101", "Casablanca", cancellationToken);
        await EnsureAuthorAsync(dbContext, driver2.Id, "Friendly and punctual driver.", "+212600000102", "Rabat", cancellationToken);
        await EnsureAuthorAsync(dbContext, passenger1.Id, "Regular passenger.", "+212600000201", "Marrakech", cancellationToken);
        await EnsureAuthorAsync(dbContext, passenger2.Id, "Tech enthusiast traveler.", "+212600000202", "Tangier", cancellationToken);
        await EnsureAuthorAsync(dbContext, passenger3.Id, "Weekend trips lover.", "+212600000203", "Agadir", cancellationToken);

        var now = DateTime.UtcNow;

        var tripCompleted = await EnsureTripAsync(
            dbContext,
            driver1.Id,
            "Casablanca",
            "Rabat",
            now.Date.AddDays(-3).AddHours(8),
            now.Date.AddDays(-3),
            now.Date.AddDays(-2),
            new TimeSpan(8, 0, 0),
            2,
            80m,
            1,
            cancellationToken);

        var tripUpcoming = await EnsureTripAsync(
            dbContext,
            driver1.Id,
            "Rabat",
            "Fes",
            now.Date.AddDays(2).AddHours(9),
            now.Date.AddDays(2),
            now.Date.AddDays(2),
            new TimeSpan(9, 0, 0),
            1,
            95m,
            4,
            cancellationToken);

        var tripOngoing = await EnsureTripAsync(
            dbContext,
            driver2.Id,
            "Marrakech",
            "Agadir",
            now.AddHours(-1),
            now.Date,
            now.Date,
            now.AddHours(-1).TimeOfDay,
            1,
            70m,
            2,
            cancellationToken);

        var res1 = await EnsureReservationAsync(dbContext, tripCompleted.Id, passenger1.Id, 1, cancellationToken);
        var res2 = await EnsureReservationAsync(dbContext, tripCompleted.Id, passenger2.Id, 2, cancellationToken);
        var res3 = await EnsureReservationAsync(dbContext, tripUpcoming.Id, passenger3.Id, 1, cancellationToken);
        var res4 = await EnsureReservationAsync(dbContext, tripOngoing.Id, passenger2.Id, 1, cancellationToken);

        await EnsurePaymentAsync(dbContext, res1, 80m, PaymentMethod.Card, PaymentStatus.Paid, "Salma Passenger", "4111111111111111", "12/30", "123", cancellationToken);
        await EnsurePaymentAsync(dbContext, res2, 160m, PaymentMethod.Cash, PaymentStatus.Pending, null, null, null, null, cancellationToken);
        await EnsurePaymentAsync(dbContext, res3, 95m, PaymentMethod.Card, PaymentStatus.Paid, "Hassan Passenger", "5555444433332222", "11/29", "456", cancellationToken);
        await EnsurePaymentAsync(dbContext, res4, 70m, PaymentMethod.Cash, PaymentStatus.Pending, null, null, null, null, cancellationToken);

        await EnsureReviewAsync(dbContext, driver1.Id, passenger1.Id, tripCompleted.Id, 5, "Excellent driver, very smooth trip.", now.AddDays(-2), cancellationToken);
        await EnsureReviewAsync(dbContext, driver1.Id, passenger2.Id, tripCompleted.Id, 4, "Good trip overall, on time.", now.AddDays(-2), cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private static async Task<User> GetOrCreateUserAsync(ApplicationDbContext dbContext, IPasswordHasher<User> passwordHasher, string name, string email, UserRole role, string password, CancellationToken cancellationToken)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == normalizedEmail, cancellationToken);
        if (user != null)
        {
            return user;
        }

        user = new User
        {
            Name = name,
            Email = normalizedEmail,
            Role = role
        };

        user.PasswordHash = passwordHasher.HashPassword(user, password);
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);
        return user;
    }

    private static async Task EnsureAuthorAsync(ApplicationDbContext dbContext, int userId, string bio, string phone, string city, CancellationToken cancellationToken)
    {
        var author = await dbContext.Authors.FirstOrDefaultAsync(a => a.UserId == userId, cancellationToken);
        if (author != null)
        {
            return;
        }

        dbContext.Authors.Add(new Author
        {
            UserId = userId,
            Bio = bio,
            Phone = phone,
            City = city,
            ProfileImageUrl = string.Empty
        });

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private static async Task<Trip> EnsureTripAsync(
        ApplicationDbContext dbContext,
        int driverId,
        string departure,
        string destination,
        DateTime departureTime,
        DateTime startDate,
        DateTime endDate,
        TimeSpan startTime,
        int numberOfDays,
        decimal pricePerSeat,
        int availableSeats,
        CancellationToken cancellationToken)
    {
        var trip = await dbContext.Trips.FirstOrDefaultAsync(t =>
            t.DriverId == driverId &&
            t.Departure == departure &&
            t.Destination == destination &&
            t.DepartureTime == departureTime,
            cancellationToken);

        if (trip != null)
        {
            return trip;
        }

        trip = new Trip
        {
            DriverId = driverId,
            Departure = departure,
            Destination = destination,
            DepartureTime = departureTime,
            StartDate = startDate,
            EndDate = endDate,
            StartTime = startTime,
            NumberOfDays = numberOfDays,
            PricePerSeat = pricePerSeat,
            AvailableSeats = availableSeats,
            CreatedAt = DateTime.UtcNow,
            Status = departureTime < DateTime.UtcNow
                ? (departureTime > DateTime.UtcNow.AddHours(-3) ? TripStatus.Ongoing : TripStatus.Completed)
                : TripStatus.Upcoming
        };

        dbContext.Trips.Add(trip);
        await dbContext.SaveChangesAsync(cancellationToken);
        return trip;
    }

    private static async Task<Reservation> EnsureReservationAsync(ApplicationDbContext dbContext, int tripId, int userId, int seatsReserved, CancellationToken cancellationToken)
    {
        var reservation = await dbContext.Reservations.FirstOrDefaultAsync(r => r.TripId == tripId && r.UserId == userId, cancellationToken);
        if (reservation != null)
        {
            return reservation;
        }

        reservation = new Reservation
        {
            TripId = tripId,
            UserId = userId,
            SeatsReserved = seatsReserved
        };

        dbContext.Reservations.Add(reservation);
        await dbContext.SaveChangesAsync(cancellationToken);
        return reservation;
    }

    private static async Task EnsurePaymentAsync(
        ApplicationDbContext dbContext,
        Reservation reservation,
        decimal amount,
        PaymentMethod method,
        PaymentStatus status,
        string? cardHolderName,
        string? cardNumber,
        string? expiryDate,
        string? cvv,
        CancellationToken cancellationToken)
    {
        var payment = await dbContext.Payments.FirstOrDefaultAsync(p => p.ReservationId == reservation.Id, cancellationToken);
        if (payment != null)
        {
            return;
        }

        dbContext.Payments.Add(new Payment
        {
            ReservationId = reservation.Id,
            Amount = amount,
            Method = method,
            Status = status,
            CardHolderName = cardHolderName,
            CardNumber = cardNumber,
            ExpiryDate = expiryDate,
            Cvv = cvv,
            CreatedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private static async Task EnsureReviewAsync(
        ApplicationDbContext dbContext,
        int driverId,
        int passengerId,
        int tripId,
        int rating,
        string comment,
        DateTime createdAt,
        CancellationToken cancellationToken)
    {
        var review = await dbContext.Reviews.FirstOrDefaultAsync(r => r.PassengerId == passengerId && r.TripId == tripId, cancellationToken);
        if (review != null)
        {
            return;
        }

        dbContext.Reviews.Add(new Review
        {
            DriverId = driverId,
            PassengerId = passengerId,
            TripId = tripId,
            Rating = rating,
            Comment = comment,
            CreatedAt = createdAt
        });

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

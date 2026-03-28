using Microsoft.EntityFrameworkCore;
using Serveur.Models.Entities;

namespace Serveur.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Trip> Trips => Set<Trip>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Review> Reviews => Set<Review>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasOne(u => u.Author)
            .WithOne(a => a.User)
            .HasForeignKey<Author>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Author>()
            .HasIndex(a => a.UserId)
            .IsUnique();

        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Driver)
            .WithMany(u => u.Trips)
            .HasForeignKey(t => t.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Trip>()
            .Property(t => t.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Trip>()
            .Property(t => t.PricePerSeat)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Trip)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasIndex(r => new { r.UserId, r.TripId })
            .IsUnique();

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Driver)
            .WithMany(u => u.ReviewsReceived)
            .HasForeignKey(r => r.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Passenger)
            .WithMany(u => u.ReviewsGiven)
            .HasForeignKey(r => r.PassengerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Trip)
            .WithMany(t => t.Reviews)
            .HasForeignKey(r => r.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
            .HasIndex(r => new { r.PassengerId, r.TripId })
            .IsUnique();

        modelBuilder.Entity<Review>()
            .Property(r => r.Comment)
            .HasMaxLength(2000);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Reservation)
            .WithOne(r => r.Payment)
            .HasForeignKey<Payment>(p => p.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Payment>()
            .HasIndex(p => p.ReservationId)
            .IsUnique();

        modelBuilder.Entity<Payment>()
            .Property(p => p.Method)
            .HasConversion<string>();

        modelBuilder.Entity<Payment>()
            .Property(p => p.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Payment>()
            .Property(p => p.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Payment>()
            .Property(p => p.CardHolderName)
            .HasMaxLength(120);

        modelBuilder.Entity<Payment>()
            .Property(p => p.CardNumber)
            .HasMaxLength(32);

        modelBuilder.Entity<Payment>()
            .Property(p => p.ExpiryDate)
            .HasMaxLength(10);

        modelBuilder.Entity<Payment>()
            .Property(p => p.Cvv)
            .HasMaxLength(10);
    }
}

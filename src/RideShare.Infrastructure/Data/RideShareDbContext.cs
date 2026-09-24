using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RideShare.Infrastructure.Data.Entities;

namespace RideShare.Infrastructure.Data;

public partial class RideShareDbContext : DbContext
{
    public RideShareDbContext(DbContextOptions<RideShareDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Ride> Rides { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.BookedAt).HasDefaultValueSql("(sysutcdatetime())", "DF_Bookings_BookedAt");
            entity.Property(e => e.Status).HasDefaultValue(1, "DF_Bookings_Status");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Passenger");

            entity.HasOne(d => d.Ride).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Rides");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasIndex(e => e.BookingId, "UQ_Payments_Booking").IsUnique();

            entity.HasIndex(e => e.TransactionId, "UQ_Payments_TransactionId").IsUnique();

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentGateway).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValue(1, "DF_Payments_Status");
            entity.Property(e => e.TransactionId).HasMaxLength(200);

            entity.HasOne(d => d.Booking).WithOne(p => p.Payment)
                .HasForeignKey<Payment>(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_Bookings");
        });

        modelBuilder.Entity<Ride>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())", "DF_Rides_CreatedAt");
            entity.Property(e => e.FromLocation).HasMaxLength(200);
            entity.Property(e => e.PricePerSeat).HasColumnType("decimal(18, 2)");
            //entity.Property(e => e.Status).HasDefaultValue(1, "DG_Rides_Status");
            entity.Property(e => e.ToLocation).HasMaxLength(200);

            entity.HasOne(d => d.Driver).WithMany(p => p.Rides)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rides_Driver");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Rides)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rides_Vehicle");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ_Users_Email").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())", "DF_User_created_At");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasIndex(e => e.VehicleNumber, "UQ_Vehicles_VehicleNumber").IsUnique();

            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysutcdatetime())", "DF_Vehicles_CreatedAt");
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.VehicleNumber).HasMaxLength(20);
            entity.Property(e => e.VehicleType).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicles_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

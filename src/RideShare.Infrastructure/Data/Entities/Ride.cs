using RideShare.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RideShare.Infrastructure.Data.Entities;

public partial class Ride
{
    public int Id { get; set; }

    public int DriverId { get; set; }

    public int VehicleId { get; set; }

    public string FromLocation { get; set; } = null!;

    public string ToLocation { get; set; } = null!;

    public DateTime DepartureDateTime { get; set; }

    public decimal PricePerSeat { get; set; }

    public int AvailableSeats { get; set; }

    //public RideStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual User Driver { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace RideShare.Infrastructure.Data.Entities;

public partial class Vehicle
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string VehicleNumber { get; set; } = null!;

    public string VehicleType { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int TotalSeats { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Ride> Rides { get; set; } = new List<Ride>();

    public virtual User User { get; set; } = null!;
}

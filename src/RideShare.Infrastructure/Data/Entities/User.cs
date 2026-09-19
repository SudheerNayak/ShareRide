using System;
using System.Collections.Generic;

namespace RideShare.Infrastructure.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Ride> Rides { get; set; } = new List<Ride>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}

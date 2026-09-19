using System;
using System.Collections.Generic;

namespace RideShare.Infrastructure.Data.Entities;

public partial class Booking
{
    public int Id { get; set; }

    public int RideId { get; set; }

    public int PassengerId { get; set; }

    public int NumberOfSeats { get; set; }

    public decimal TotalAmount { get; set; }

    public int Status { get; set; }

    public DateTime BookedAt { get; set; }

    public virtual User Passenger { get; set; } = null!;

    public virtual Payment? Payment { get; set; }

    public virtual Ride Ride { get; set; } = null!;
}

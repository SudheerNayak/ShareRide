using System;
using System.Collections.Generic;

namespace RideShare.Infrastructure.Data.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentGateway { get; set; } = null!;

    public string? TransactionId { get; set; }

    public int Status { get; set; }

    public DateTime? PaidAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}

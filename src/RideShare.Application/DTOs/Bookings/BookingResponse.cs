namespace RideShare.Application.DTOs.Bookings;

public class BookingResponse
{
    public int Id { get; set; }

    public int RideId { get; set; }

    public int PassengerId { get; set; }

    public int NumberOfSeats { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime BookedAt { get; set; }
}

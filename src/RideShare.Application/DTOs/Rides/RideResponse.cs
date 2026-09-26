namespace RideShare.Application.DTOs.Rides;

public class RideResponse
{
    public int Id { get; set; }

    public int DriverId { get; set; }

    public int VehicleId { get; set; }

    public string FromLocation { get; set; } = string.Empty;

    public string ToLocation { get; set; } = string.Empty;

    public DateTime DepartureDateTime { get; set; }

    public decimal PricePerSeat { get; set; }

    public int AvailableSeats { get; set; }

    //public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace RideShare.Application.DTOs.Rides;

public class CreateRideRequest
{
    [Required]
    public int DriverId { get; set; }
    [Required]
    public int VehicleId { get; set; }
    [Required]
    [MaxLength(200)]
    public string FromLocation { get; set; } = string.Empty;
    [Required]
    [MaxLength(200)]
    public string ToLocation { get; set; } = string.Empty;
    [Required]
    public DateTime DepartureDateTime { get; set; }
    [Range(1,10)]
    public int AvailableSeats { get; set; }
    [Range(1,10000)]
    public decimal PricePerSeat { get; set; }
}
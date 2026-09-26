using System.ComponentModel.DataAnnotations;

namespace RideShare.Application.DTOs.Rides;

public class SearchRideRequest
{
    [Required]
    public string FromLocation { get; set; } = string.Empty;

    [Required]
    public string ToLocation { get; set; } = string.Empty;

    [Required]
    public DateTime DepartureDate { get; set; }
}
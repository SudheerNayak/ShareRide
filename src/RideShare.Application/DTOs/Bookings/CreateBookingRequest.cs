

using System.ComponentModel.DataAnnotations;

namespace RideShare.Application.DTOs.Bookings;

public class CreateBookingRequest
{
    [Range(0, int.MaxValue)]
    public  int RideId { get; set; }
    [Range(0, int.MaxValue)]
    public int PassengerId { get; set; }
    [Range(1, 10)]
    public int NumberOfSeats { get; set; }

}

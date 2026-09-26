using RideShare.Application.DTOs.Rides;
using RideShare.Domain.Entities;

namespace RideShare.Application.Mappers;

public static class RideResponseMapper
{
    public static RideResponse ToResponse(Ride ride)
    {
        return new RideResponse
        {
            Id = ride.Id,
            DriverId = ride.DriverId,
            VehicleId = ride.VehicleId,
            FromLocation = ride.FromLocation,
            ToLocation = ride.ToLocation,
            DepartureDateTime = ride.DepartureDateTime,
            PricePerSeat = ride.PricePerSeat,
            AvailableSeats = ride.AvailableSeats,
           // Status = ride.Status.ToString(),
            CreatedAt = ride.CreatedAt
        };
    }
}
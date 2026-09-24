using DomainRide = RideShare.Domain.Entities.Ride;
using DatabaseRide = RideShare.Infrastructure.Data.Entities.Ride;
using RideShare.Domain.Enums;

namespace RideShare.Infrastructure.Mappers;

public static class RideMapper
{
    public static DomainRide ToDomain(DatabaseRide entity)
    {
        return DomainRide.Rehydrate(id: entity.Id,driverId: entity.DriverId,
            vehicleId: entity.VehicleId,fromLocation: entity.FromLocation,
            toLocation: entity.ToLocation,departureDateTime: entity.DepartureDateTime,
            pricePerSeat: entity.PricePerSeat,availableSeats: entity.AvailableSeats,
            //status: (RideStatus)entity.Status,
            createdAt: entity.CreatedAt);
    }

    public static DatabaseRide ToDatabase(DomainRide entity)
    {
        return new DatabaseRide
        {
            Id = entity.Id,
            DriverId = entity.DriverId,
            VehicleId = entity.VehicleId,
            FromLocation = entity.FromLocation,
            ToLocation = entity.ToLocation,
            DepartureDateTime = entity.DepartureDateTime,
            PricePerSeat = entity.PricePerSeat,
            AvailableSeats = entity.AvailableSeats,
            //Status = (RideStatus)entity.Status,
            CreatedAt = entity.CreatedAt
        };
    }
}
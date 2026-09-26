using DomainVehicle = RideShare.Domain.Entities.Vehicle;
using DatabaseVehicle = RideShare.Infrastructure.Data.Entities.Vehicle;

namespace RideShare.Infrastructure.Mappers;

public static class VehicleMapper
{
    public static DomainVehicle ToDomain(DatabaseVehicle entity)
    {
        return DomainVehicle.Rehydrate(
            id: entity.Id,
            userId: entity.UserId,
            vehicleNumber: entity.VehicleNumber,
            vehicleType: entity.VehicleType,
            brand: entity.Brand,
            model: entity.Model,
            totalSeats: entity.TotalSeats,
            createdDate: entity.CreatedDate);
    }
}
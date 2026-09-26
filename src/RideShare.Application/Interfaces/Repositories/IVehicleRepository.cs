using System;
using RideShare.Domain.Entities;

public interface IVehicleRepository
{
	Task<Vehicle?> GetByIdOwnerAsync(int vehicleId, int ownerId, CancellationToken cancellationToken);
}

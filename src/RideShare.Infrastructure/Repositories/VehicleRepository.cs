using Microsoft.EntityFrameworkCore;
using RideShare.Domain.Entities;
using RideShare.Infrastructure.Data;
using RideShare.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly RideShareDbContext _context;
        public VehicleRepository(RideShareDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle?> GetByIdOwnerAsync(int vehicleId, int ownerId, CancellationToken cancellationToken)
        {
            var vehicleEntity = await _context.Vehicles
             .AsNoTracking()
             .FirstOrDefaultAsync(
                 vehicle =>
                     vehicle.Id == vehicleId &&
                     vehicle.UserId == ownerId,
                 cancellationToken);
            if(vehicleEntity is null)
            {
                return null;
            }

            return VehicleMapper.ToDomain(vehicleEntity);
        }
    }
}

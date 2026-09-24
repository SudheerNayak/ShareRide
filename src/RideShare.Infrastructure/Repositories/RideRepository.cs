using System;
using Microsoft.EntityFrameworkCore;
using RideShare.Application.Interfaces.Repository;
using RideShare.Domain.Entities;
using RideShare.Domain.Enums;
using RideShare.Infrastructure.Data;
using RideShare.Infrastructure.Mappers;

namespace RideShare.Infrastructure.Repositories;

public class RideRepository : IRideRepository
{
    private readonly RideShareDbContext _context;
    public RideRepository(RideShareDbContext context)
    {
        _context = context;
    }

    public void Add(Ride ride)
    {
        var rideEntity = RideMapper.ToDatabase(ride);

        _context.Rides.Add(rideEntity);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Ride?> GetByIdAsync(int rideId, CancellationToken cancellationToken = default)
    {
        var rideEntity = await _context.Rides
            .AsNoTracking()
            .FirstOrDefaultAsync(
            ride=> ride.Id== rideId, cancellationToken);
        if(rideEntity is null)
        {
            return null;
        }
        return RideMapper.ToDomain(rideEntity);

    }

    

    public async Task<IReadOnlyList<Ride>> SearchAsync(string fromLocation,string toLocation,DateTime departureDate,CancellationToken cancellationToken = default)
    {
        var nextDate = departureDate.Date.AddDays(1);

        var rideEntities = await _context.Rides
            .AsNoTracking()
            .Where(ride =>
                ride.FromLocation == fromLocation &&
                ride.ToLocation == toLocation &&
                ride.DepartureDateTime >= departureDate.Date &&
                ride.DepartureDateTime < nextDate &&
                //ride.Status == 1 &&
                ride.AvailableSeats > 0).OrderBy(ride => ride.DepartureDateTime).ToListAsync(cancellationToken);

        return rideEntities.Select(RideMapper.ToDomain).ToList();
    }
}

using System;
using RideShare.Domain.Entities;

namespace RideShare.Application.Interfaces.Repository;

public interface IRideRepository
{
	Task<Ride?> GetByIdAsync(int rideId, CancellationToken cancellation = default);
	Task<IReadOnlyList<Ride>> SearchAsync(string fromLocation, string toLocation, DateTime departureDate, CancellationToken cancellation = default);
    public void Add(Ride ride);

    Task SaveChangesAsync(CancellationToken cancellation = default);
}

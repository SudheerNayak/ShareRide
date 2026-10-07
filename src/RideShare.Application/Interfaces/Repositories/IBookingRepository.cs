using RideShare.Domain.Entities;

namespace RideShare.Application.Interfaces.Repositories;

public interface IBookingRepository
{
    Task<Booking> AddAsync(Booking booking,CancellationToken cancellationToken = default);
}
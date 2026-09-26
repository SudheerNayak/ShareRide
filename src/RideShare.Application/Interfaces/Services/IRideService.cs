using RideShare.Application.DTOs.Rides;

namespace RideShare.Application.Interfaces.Services;

public interface IRideService
{
    Task<RideResponse?> GetByIdAsync(
        int rideId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RideResponse>> SearchAsync(
        SearchRideRequest request,
        CancellationToken cancellationToken = default);

    Task<RideResponse> CreateAsync(
        CreateRideRequest request,
        CancellationToken cancellationToken = default);
}
using RideShare.Application.DTOs.Rides;
using RideShare.Application.Interfaces.Repository;
using RideShare.Application.Interfaces.Services;
using RideShare.Application.Mappers;
using RideShare.Domain.Entities;
using System;

namespace RideShare.Application.Services;

public class RideService:IRideService
{
    private readonly IRideRepository _rideRepository;
    private readonly IVehicleRepository _vehicleRepository;
    public RideService(IRideRepository rideRepository, IVehicleRepository vehicleRepository)
    {
        _rideRepository = rideRepository;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<RideResponse> CreateAsync(CreateRideRequest request, CancellationToken cancellationToken = default)
    {
        var vehicle = _vehicleRepository.GetByIdOwnerAsync(request.VehicleId, request.DriverId, cancellationToken);
        if(vehicle is null)
        {
            throw new InvalidOperationException("Vehicle does not exist or not belong to the driver");
        }
        //if(request.AvailableSeats > vehicle.totalSeats)
        //{
        //    throw new InvalidOperationException($"Available seats cannot exceed vehicle capacity of {vehicle.totalCapacity}");
        //}

        ValidateCreateRequest(request);

        var ride = new Ride(
            driverId: request.DriverId,
            vehicleId: request.VehicleId,
            fromLocation: request.FromLocation.Trim(),
            toLocation: request.ToLocation.Trim(),
            departureDateTime: request.DepartureDateTime,
            pricePerSeat: request.PricePerSeat,
            availableSeats: request.AvailableSeats);

        await _rideRepository.AddAsync(ride, cancellationToken);

       // await _rideRepository.SaveChangesAsync(cancellationToken);

        // We will improve ID handling shortly.
        return RideResponseMapper.ToResponse(ride);
    }

    private void ValidateCreateRequest(CreateRideRequest request)
    {
        if (request.DriverId <= 0)
        {
            throw new ArgumentException(
                "Driver ID must be greater than zero.");
        }

        if (request.VehicleId <= 0)
        {
            throw new ArgumentException(
                "Vehicle ID must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(request.FromLocation))
        {
            throw new ArgumentException(
                "From location is required.");
        }

        if (string.IsNullOrWhiteSpace(request.ToLocation))
        {
            throw new ArgumentException(
                "To location is required.");
        }

        if (request.FromLocation.Trim()
            .Equals(
                request.ToLocation.Trim(),
                StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException(
                "From and To locations cannot be the same.");
        }

        if (request.DepartureDateTime <= DateTime.UtcNow)
        {
            throw new ArgumentException(
                "Departure time must be in the future.");
        }

        if (request.AvailableSeats <= 0)
        {
            throw new ArgumentException(
                "Available seats must be greater than zero.");
        }

        if (request.PricePerSeat <= 0)
        {
            throw new ArgumentException(
                "Price per seat must be greater than zero.");
        }
    }

    public async Task<RideResponse?> GetByIdAsync(int rideId, CancellationToken cancellationToken = default)
    {
        if(rideId<=0)
        {
            throw new ArgumentException("Ride Id must be greater than zero. ");
        }
        var ride = await _rideRepository.GetByIdAsync(rideId, cancellationToken);
        if(ride is null)
        {
            return null;
        }

        return RideResponseMapper.ToResponse(ride);
      
    }

    public async Task<IReadOnlyList<RideResponse>> SearchAsync(SearchRideRequest request, CancellationToken cancellationToken = default)
    {
        ValidateSearchRequest(request);
        var rides = await _rideRepository.SearchAsync(
            request.FromLocation.Trim(),
            request.ToLocation.Trim(),
            request.DepartureDate,
            cancellationToken);
        return rides.Select(RideResponseMapper.ToResponse).ToList();
    }

    private void ValidateSearchRequest(SearchRideRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FromLocation))
        {
            throw new ArgumentException(
                "From location is required.");
        }

        if (string.IsNullOrWhiteSpace(request.ToLocation))
        {
            throw new ArgumentException(
                "To location is required.");
        }

        if (request.FromLocation.Trim()
            .Equals(
                request.ToLocation.Trim(),
                StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException(
                "From and To locations cannot be the same.");
        }

        if (request.DepartureDate.Date < DateTime.UtcNow.Date)
        {
            throw new ArgumentException(
                "Departure date cannot be in the past.");
        }
    }
}


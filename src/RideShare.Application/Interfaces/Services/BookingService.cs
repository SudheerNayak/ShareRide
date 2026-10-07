using RideShare.Application.DTOs.Bookings;
using RideShare.Application.Interfaces;
using RideShare.Application.Interfaces.Repositories;
using RideShare.Application.Interfaces.Repository;
using RideShare.Application.Interfaces.Services;
using RideShare.Domain.Entities;

namespace RideShare.Application.Services;

public class BookingService : IBookingService
{
    private readonly IRideRepository _rideRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookingService(IRideRepository rideRepository,IBookingRepository bookingRepository,IUnitOfWork unitOfWork)
    {
        _rideRepository = rideRepository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    //public async Task<BookingResponse> CreateAsync(CreateBookingRequest request,CancellationToken cancellationToken = default)
    //{
    //    //ValidateRequest(request);

    //    //var ride = await _rideRepository.GetByIdAsync(
    //    //    request.RideId,
    //    //    cancellationToken);

    //    //if (ride is null)
    //    //{
    //    //    throw new InvalidOperationException(
    //    //        "Ride was not found.");
    //    //}

    //    //if (ride.DriverId == request.PassengerId)
    //    //{
    //    //    throw new InvalidOperationException(
    //    //        "Driver cannot book their own ride.");
    //    //}

    //    //var totalAmount =ride.PricePerSeat * request.NumberOfSeats;

    //    //await _unitOfWork.BeginTransactionAsync(
    //    //    cancellationToken);

    //    //try
    //    //{
    //    //    var seatsReserved =
    //    //        await _rideRepository.TryReserveSeatsAsync(
    //    //            request.RideId,
    //    //            request.NumberOfSeats,
    //    //            cancellationToken);

    //    //    if (!seatsReserved)
    //    //    {
    //    //        throw new InvalidOperationException(
    //    //            "The requested number of seats is no longer available.");
    //    //    }

    //    //    var booking = new Booking(
    //    //        rideId: request.RideId,
    //    //        passengerId: request.PassengerId,
    //    //        numberOfSeats: request.NumberOfSeats,
    //    //        totalAmount: totalAmount);

    //    //    await _bookingRepository.AddAsync(
    //    //        booking,
    //    //        cancellationToken);

    //    //    await _unitOfWork.SaveChangesAsync(
    //    //        cancellationToken);

    //    //    await _unitOfWork.CommitTransactionAsync(
    //    //        cancellationToken);

    //        return new BookingResponse
    //        {
    //            Id = booking.Id,
    //            RideId = booking.RideId,
    //            PassengerId = booking.PassengerId,
    //            NumberOfSeats = booking.NumberOfSeats,
    //            TotalAmount = booking.TotalAmount,
    //            //Status = booking.Status.ToString(),
    //            BookedAt = booking.BookedAt
    //        };
    //    }
    //    catch
    //    {
    //        await _unitOfWork.RollbackTransactionAsync(
    //            cancellationToken);

    //        throw;
    //    }
    //}

    private static void ValidateRequest(CreateBookingRequest request)
    {
        if (request.RideId <= 0)
        {
            throw new ArgumentException(
                "Ride ID must be greater than zero.");
        }

        if (request.PassengerId <= 0)
        {
            throw new ArgumentException(
                "Passenger ID must be greater than zero.");
        }

        if (request.NumberOfSeats <= 0)
        {
            throw new ArgumentException(
                "Number of seats must be greater than zero.");
        }
    }

    public Task<BookingResponse> CreateAsync(CreateBookingRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
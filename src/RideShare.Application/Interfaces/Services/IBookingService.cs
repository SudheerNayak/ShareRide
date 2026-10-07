using RideShare.Application.DTOs.Bookings;
using System;

namespace RideShare.Application.Interfaces.Services;

interface IBookingService
{
    Task<BookingResponse> CreateAsync(CreateBookingRequest request, CancellationToken cancellationToken = default);
}


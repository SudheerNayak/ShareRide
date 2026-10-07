using RideShare.Application.Interfaces.Repositories;
using RideShare.Domain.Entities;
using RideShare.Infrastructure.Data;
using RideShare.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Infrastructure.Repositories
{
    public class BookingRepository:IBookingRepository
    {
        private readonly RideShareDbContext _context;
        public BookingRepository(RideShareDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> AddAsync(Booking booking, CancellationToken cancellationToken = default)
        {
            var bookingEntity = BookingMapper.ToDatabase(booking);
            await _context.Bookings.AddAsync(bookingEntity, cancellationToken);
           // await _context.SaveChangesAsync(cancellationToken); 
            return BookingMapper.ToDomain(bookingEntity);
            
        }
    }
}

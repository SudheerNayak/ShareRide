using DomainBooking = RideShare.Domain.Entities.Booking;
using DatabaseBooking = RideShare.Infrastructure.Data.Entities.Booking;
using RideShare.Domain.Enums;

namespace RideShare.Infrastructure.Mappers;

public static class BookingMapper
{
    public static DomainBooking ToDomain(
        DatabaseBooking entity)
    {
        return DomainBooking.Rehydrate(
            id: entity.Id,
            rideId: entity.RideId,
            passengerId: entity.PassengerId,
            numberOfSeats: entity.NumberOfSeats,
            totalAmount: entity.TotalAmount,
            //status: (BookingStatus)entity.Status,
            bookedAt: entity.BookedAt);
    }

    public static DatabaseBooking ToDatabase(
        DomainBooking entity)
    {
        return new DatabaseBooking
        {
            Id = entity.Id,
            RideId = entity.RideId,
            PassengerId = entity.PassengerId,
            NumberOfSeats = entity.NumberOfSeats,
            TotalAmount = entity.TotalAmount,
            //Status = (int)entity.Status,
            BookedAt = entity.BookedAt
        };
    }
}
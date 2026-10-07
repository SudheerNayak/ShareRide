using RideShare.Domain.Enums;

namespace RideShare.Domain.Entities;

public class Booking
{
    private Booking()
    {
    }

    private Booking(int id,int rideId,int passengerId,int numberOfSeats,decimal totalAmount /*BookingStatus status*/,
        DateTime bookedAt)
    {
        Id = id;
        RideId = rideId;
        PassengerId = passengerId;
        NumberOfSeats = numberOfSeats;
        TotalAmount = totalAmount;
        //Status = status;
        BookedAt = bookedAt;
    }

    public Booking(int rideId,int passengerId,int numberOfSeats,decimal totalAmount)
    {
        RideId = rideId;
        PassengerId = passengerId;
        NumberOfSeats = numberOfSeats;
        TotalAmount = totalAmount;
        //Status = BookingStatus.Pending;
        BookedAt = DateTime.UtcNow;
    }

    public int Id { get; private set; }

    public int RideId { get; private set; }

    public int PassengerId { get; private set; }

    public int NumberOfSeats { get; private set; }

    public decimal TotalAmount { get; private set; }

    //public BookingStatus Status { get; private set; }

    public DateTime BookedAt { get; private set; }

    public static Booking Rehydrate(int id,int rideId,int passengerId,int numberOfSeats,decimal totalAmount,/*BookingStatus status,*/ DateTime bookedAt)
    {
        return new Booking(
            id,
            rideId,
            passengerId,
            numberOfSeats,
            totalAmount,
            //status,
            bookedAt);
    }
}
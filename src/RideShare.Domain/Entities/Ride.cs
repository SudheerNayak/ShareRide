using RideShare.Domain.Enums;

namespace RideShare.Domain.Entities;

public class Ride
{
    private Ride()
    {
    }

    private Ride(int id,int driverId,int vehicleId,string fromLocation,string toLocation,DateTime departureDateTime,decimal pricePerSeat,int availableSeats,/*RideStatus status,*/ DateTime createdAt)
    {
        Id = id;
        DriverId = driverId;
        VehicleId = vehicleId;
        FromLocation = fromLocation;
        ToLocation = toLocation;
        DepartureDateTime = departureDateTime;
        PricePerSeat = pricePerSeat;
        AvailableSeats = availableSeats;
        //Status = status;
        CreatedAt = createdAt;
    }

    public Ride(int driverId,int vehicleId,string fromLocation,string toLocation,DateTime departureDateTime,decimal pricePerSeat,int availableSeats)
    {
        DriverId = driverId;
        VehicleId = vehicleId;
        FromLocation = fromLocation;
        ToLocation = toLocation;
        DepartureDateTime = departureDateTime;
        PricePerSeat = pricePerSeat;
        AvailableSeats = availableSeats;
        //Status = RideStatus.rideStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; private set; }

    public int DriverId { get; private set; }

    public int VehicleId { get; private set; }

    public string FromLocation { get; private set; } = string.Empty;

    public string ToLocation { get; private set; } = string.Empty;

    public DateTime DepartureDateTime { get; private set; }

    public decimal PricePerSeat { get; private set; }

    public int AvailableSeats { get; private set; }

   // public RideStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static Ride Rehydrate(int id,int driverId,int vehicleId,string fromLocation,string toLocation,DateTime departureDateTime,decimal pricePerSeat,int availableSeats,/*RideStatus status,*/ DateTime createdAt)
    {
        return new Ride(
            id,
            driverId,
            vehicleId,
            fromLocation,
            toLocation,
            departureDateTime,
            pricePerSeat,
            availableSeats,
            //status,
            createdAt);
    }
}

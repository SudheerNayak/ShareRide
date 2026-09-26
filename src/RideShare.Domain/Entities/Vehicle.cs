namespace RideShare.Domain.Entities;

public class Vehicle
{
    private Vehicle()
    {
    }

    private Vehicle(int id,int userId,string vehicleNumber,string vehicleType,string brand,string model,int totalSeats,DateTime createdDate)
    {
        Id = id;
        UserId = userId;
        VehicleNumber = vehicleNumber;
        VehicleType = vehicleType;
        Brand = brand;
        Model = model;
        TotalSeats = totalSeats;
        CreatedDate = createdDate;
    }

    public int Id { get; private set; }

    public int UserId { get; private set; }

    public string VehicleNumber { get; private set; } = string.Empty;

    public string VehicleType { get; private set; } = string.Empty;

    public string Brand { get; private set; } = string.Empty;

    public string Model { get; private set; } = string.Empty;

    public int TotalSeats { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public static Vehicle Rehydrate(int id,int userId,string vehicleNumber,string vehicleType,string brand,string model,int totalSeats,DateTime createdDate)
    {
        return new Vehicle(
            id,
            userId,
            vehicleNumber,
            vehicleType,
            brand,
            model,
            totalSeats,
            createdDate);
    }
}
using System;

namespace RideShare.Domain.Enums;

public class BookingStatus
{
	public enum bookingStatus
	{
		Pending=1,
		Confirmed=2,
		Cancelled=3,
		Completed=4
	}
}

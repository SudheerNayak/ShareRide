using System;

namespace RideShare.Domain.Enums;

public class PaymentStatus
{
	public enum paymentStatus
	{
		Pending=1,
		Successful=2,
		Failed=3,
		Refunded=4
	}
}

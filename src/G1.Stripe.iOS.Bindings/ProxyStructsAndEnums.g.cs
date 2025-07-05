namespace Stripe
{
	public enum TSPSCardBrand
	{
		Visa = 0,
		Amex = 1,
		MasterCard = 2,
		Discover = 3,
		Jcb = 4,
		DinersClub = 5,
		UnionPay = 6,
		Unknown = 7
	}

	public enum TSPSPaymentMethodType
	{
		Card = 0,
		CardPresent = 1,
		Ideal = 2,
		Sepa = 3,
		AUBECSDebit = 4,
		BacsDebit = 5,
		Sofort = 6,
		Upi = 7,
		NetBanking = 8,
		Unknown = 9
	}

	public enum TSPSPaymentSheetResult
	{
		Completed = 0,
		Canceled = 1,
		Failed = 2
	}

	public enum TSPSUserInterfaceStyle
	{
		utomatic = 0,
		lwaysLight = 1,
		lwaysDark = 2
	}
}

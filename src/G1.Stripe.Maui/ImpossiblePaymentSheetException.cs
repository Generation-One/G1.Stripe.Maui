namespace G1.Stripe.Maui;

public class ImpossiblePaymentSheetException : Exception
{
    public ImpossiblePaymentSheetException(string? message) : base(message)
    { }
}

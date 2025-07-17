namespace G1.Stripe.Maui;

public record PaymentSheetResult
{
    public record Canceled : PaymentSheetResult;
    public record Completed : PaymentSheetResult;
    public record Failed(Exception error) : PaymentSheetResult;
}

namespace G1.Stripe.Maui;

public class PaymentSheetOptions
{
    public required string ClientSecret { get; set; }
    public required string MerchantDisplayName { get; set; }
    public string? EphemeralKey { get; set; }
    public string? CustomerId { get; set; }
}

using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

StripeConfiguration.ApiKey = builder.Configuration["Stripe:ApiKey"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.MapGet("/intent", async () =>
{
    var customerService = new CustomerService();
    var customer = (await customerService.ListAsync()).FirstOrDefault();

    if (customer == null)
    {
        customer = await customerService.CreateAsync(new CustomerCreateOptions
        {
            Name = "Dev Eloper"
        });
    }

    var ephemeral = await new EphemeralKeyService().CreateAsync(new EphemeralKeyCreateOptions
    {
        Customer = customer.Id,
        StripeVersion = "2025-05-28.basil"
    });

    var intentService = new PaymentIntentService();

    var paymentIntentOptions = new PaymentIntentCreateOptions
    {
        Amount = 1000,
        Currency = "eur",
        Customer = customer.Id,
        AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
        {
            AllowRedirects = "never",
            Enabled = true,
        },
        UseStripeSdk = true
    };

    var data = await intentService.CreateAsync(paymentIntentOptions);
    return new PaymentInfo(builder.Configuration["Stripe:PublishableKey"]!, data.ClientSecret, customer.Id, ephemeral.Secret);
})
.WithName("GetWeatherForecast");

app.Run();

public record PaymentInfo(string PublishableKey, string ClientSecret, string CustomerId, string Ephemeral);
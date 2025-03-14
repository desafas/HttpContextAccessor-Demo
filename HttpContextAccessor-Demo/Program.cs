using HttpContextAccessor_Demo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<PaymentHandler>();

builder.Services.AddScoped<PaymentService>();

builder.Services.AddTransient<OldPaymentVendor>();

builder.Services.AddTransient<NewPaymentVendor>();

builder.Services.AddScoped<Func<bool, IPaymentStrategy>>(serviceProvider => useNewVendor =>
    useNewVendor
        ? serviceProvider.GetRequiredService<NewPaymentVendor>()
        : serviceProvider.GetRequiredService<OldPaymentVendor>()
);


var app = builder.Build();

app.MapPost("/processpayment", async (HttpContext context, PaymentHandler paymentHandler) =>
{
    try
    {
        await paymentHandler.HandlePayment();
        return Results.Ok();
    }
    catch (Exception)
    {
        return Results.Problem();
    }
});

app.Run();
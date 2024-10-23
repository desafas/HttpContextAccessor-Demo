namespace HttpContextAccessor_Demo;

public class NewPaymentVendor : IPaymentStrategy
{
    private readonly ILogger<NewPaymentVendor> _logger;

    public NewPaymentVendor(ILogger<NewPaymentVendor> logger)
    {
        _logger = logger;
    }

    public async Task ProcessPayment()
    {
        _logger.LogInformation("Processing payment using {0}", nameof(NewPaymentVendor));
        await Task.CompletedTask;
    }
}

namespace HttpContextAccessor_Demo;

public class OldPaymentVendor : IPaymentStrategy
{
    private readonly ILogger<OldPaymentVendor> _logger;

    public OldPaymentVendor(ILogger<OldPaymentVendor> logger)
    {
        _logger = logger;
    }

    public async Task ProcessPayment()
    {
        _logger.LogInformation("Processing payment using {0}", nameof(OldPaymentVendor));
        await Task.CompletedTask;
    }
}

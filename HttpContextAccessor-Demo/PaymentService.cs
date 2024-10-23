namespace HttpContextAccessor_Demo;

public class PaymentService
{
    private readonly Func<bool, IPaymentStrategy> _paymentStrategyResolver;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PaymentService(
        Func<bool, IPaymentStrategy> paymentStrategyResolver, 
        IHttpContextAccessor httpContextAccessor)
    {
        _paymentStrategyResolver = paymentStrategyResolver;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task ProcessPayment()
    {
        var useNewVendor = false;
        if (_httpContextAccessor.HttpContext?.Request.Headers.TryGetValue("UseNewVendor", out var useNewVendorHeader) == true)
        {
            bool.TryParse(useNewVendorHeader, out useNewVendor);
        }

        var paymentService = _paymentStrategyResolver.Invoke(useNewVendor);

        await paymentService.ProcessPayment();
    }
}

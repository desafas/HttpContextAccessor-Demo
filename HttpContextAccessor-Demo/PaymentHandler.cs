namespace HttpContextAccessor_Demo;

public class PaymentHandler
{
    private readonly PaymentService _paymentService;

    public PaymentHandler(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task HandlePayment()
    {
        await _paymentService.ProcessPayment();
    }
}

namespace HttpContextAccessor_Demo;

public interface IPaymentStrategy
{
    public Task ProcessPayment();
}
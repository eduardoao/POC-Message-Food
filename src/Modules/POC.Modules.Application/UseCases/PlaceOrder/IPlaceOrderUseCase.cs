using POC.Modules.InputPorts.Order;


namespace POC.Modules.Application.Commands.PlaceOrder
{
    public interface IPlaceOrderUseCase
    {
        string Execute(OrderInput orderInput);
        
    }
}

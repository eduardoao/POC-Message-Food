using POC.Modules.Domain.Entities;

namespace POC.Modules.Application.Abstractions.Commands
{
    public interface IOrderWriteRepository
    {
        string PlaceOrder(Order order); 
    }
}

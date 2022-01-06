using POC.Adapters.MySqlDataAccess.Context;
using POC.Modules.Application.Abstractions.Commands;
using POC.Modules.Domain.Entities;

namespace POC.Adapters.MySqlDataAccess.WriteOnlyRepositories
{
    public class OrderWriteRepository : IOrderWriteRepository
    {
        private readonly MySqlContext _context;

        public OrderWriteRepository(MySqlContext context)
        {
            _context = context;
        }

        public string PlaceOrder(Order order) 
        {

            _context.Orders.Add(order);
            _context.SaveChanges();
           
            return order.Id.ToString(); 
        }
    }
}

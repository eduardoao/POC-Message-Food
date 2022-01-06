using System;
using System.Linq;
using POC.Adapters.MySqlDataAccess.Context;
using POC.Modules.Application.Abstractions.Queries;
using POC.Modules.Domain.Entities;

namespace POC.Adapters.MySqlDataAccess.ReadOnlyRepositories
{
    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        private readonly MySqlContext _context;   

        public CustomerReadOnlyRepository(MySqlContext context)
        {
            _context = context;
        }

        public CustomerReadOnlyRepository()
        {

        }
        public Customer Get(Guid id)
        {
            var customer =  _context.Customers              
                .Where(c => c.Id == id)
                .SingleOrDefault();

            return customer;
        }
    }
}

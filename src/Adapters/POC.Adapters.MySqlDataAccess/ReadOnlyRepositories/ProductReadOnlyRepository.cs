using System;
using System.Linq;
using POC.Adapters.MySqlDataAccess.Context;
using POC.Modules.Application.Abstractions.Queries;
using POC.Modules.Domain.Entities;
using POC.Modules.Domain.Enums;

namespace POC.Adapters.MySqlDataAccess.ReadOnlyRepositories
{
    public class ProductReadOnlyRepository : IProductReadOnlyRepository
    {
        private readonly MySqlContext _context;

        public ProductReadOnlyRepository(MySqlContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            var product = _context.Products
                .Where(c => c.Id == id)
                .SingleOrDefault();

            return product;
        }

        public Product GetByNameAndArea(string name)
        {
            var customer = _context.Products
              .Where(c => c.Title == name)            
              .FirstOrDefault();

            return customer;
        }
    }
}

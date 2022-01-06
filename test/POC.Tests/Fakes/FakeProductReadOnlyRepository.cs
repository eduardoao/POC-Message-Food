using System;
using POC.Modules.Application.Abstractions.Queries;
using POC.Modules.Domain.Entities;
using POC.Modules.Domain.ValueObjects;

namespace POC.Tests.Fakes
{
    public class FakeProductReadOnlyRepository : IProductReadOnlyRepository
    {
        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Product GetByNameAndArea(string name)
        {
            return new Product("Coke", "Drink", "", 4.5M, 100);
        }

        Product IProductReadOnlyRepository.Get(Guid id)
        {
            return new Product("Coke", "Drink", "", 4.5M, 100);
        }
    }
}

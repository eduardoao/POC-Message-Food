using System;
using POC.Modules.Application.Abstractions.Queries;
using POC.Modules.Domain.Entities;
using POC.Modules.Domain.ValueObjects;

namespace POC.Tests.Fakes
{
    public class FakeCustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        public Customer Get(Guid id)
        {
            var name = new NameVo("Eduardo", "Oliveira");
            var cpf = new CpfVo("41656058162");
            var email = new EmailVo("eoalcantara@gmail.com");

            return new Customer(name, cpf, email, "(11)5555-5555");
        }
    }
}

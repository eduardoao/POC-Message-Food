using POC.Modules.Application.Abstractions.Commands;
using POC.Modules.Domain.Entities;
using System;

namespace POC.Tests.Fakes
{
    public class FakeOrderWriteRepository : IOrderWriteRepository
    {
        public string PlaceOrder(Order order) 
        {
            return Guid.NewGuid().ToString();
        }
    }
}

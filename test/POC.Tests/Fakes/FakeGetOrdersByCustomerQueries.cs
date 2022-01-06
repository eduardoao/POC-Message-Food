using System;
using System.Collections.Generic;
using POC.Modules.Application.Queries;
using POC.Modules.Domain.Entities;

namespace POC.Tests.Fakes
{
    public class FakeGetOrdersByCustomerQueries : IGetOrdersByCustomerQueries
    {
        public IEnumerable<Order> GetOrder(Guid orderId)
        {
            return new List<Order>();
        }
    }
}
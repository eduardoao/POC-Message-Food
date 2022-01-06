using System;
using System.Collections.Generic;
using POC.Modules.Domain.Entities;

namespace POC.Modules.Application.Queries
{
    public interface IGetOrdersByCustomerQueries
    {
        IEnumerable<Order> GetOrder(Guid orderId);
    }
}
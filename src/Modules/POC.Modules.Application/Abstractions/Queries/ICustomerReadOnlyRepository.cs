using System;
using POC.Modules.Domain.Entities;

namespace POC.Modules.Application.Abstractions.Queries
{
    public interface ICustomerReadOnlyRepository
    {
        Customer Get(Guid id);
    }
}

using System;
using POC.Modules.Domain.Entities;
using POC.Modules.Domain.Enums;

namespace POC.Modules.Application.Abstractions.Queries
{
    public interface IProductReadOnlyRepository
    {
        Product GetByNameAndArea(string name);
        Product Get(Guid id);
    }
}

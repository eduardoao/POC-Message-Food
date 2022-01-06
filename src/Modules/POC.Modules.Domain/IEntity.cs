using System;
using System.ComponentModel.DataAnnotations;

namespace POC.Modules.Domain
{
    public interface IEntity
    {        
        Guid Id { get; set; }
    }
}

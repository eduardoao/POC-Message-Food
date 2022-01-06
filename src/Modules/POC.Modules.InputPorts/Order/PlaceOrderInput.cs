using System;

namespace POC.Modules.InputPorts.Order
{
    public sealed class PlaceOrderInput
    {
        public Guid CustomerId { get; set; }

        public OrderInput OrderInput { get; set; }
        
    }

}

using System;

namespace POC.Modules.InputPorts.Order
{
    public class PlaceOrderItentInput
    {
        public Guid OrderId { get; set; }      

        public OrderItemInput OrderProductItem { get; set; }
    }
  
}

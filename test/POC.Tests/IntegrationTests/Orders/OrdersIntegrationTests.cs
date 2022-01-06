using Flunt.Notifications;
using NUnit.Framework;
using System;
using POC.Modules.Application.Commands.PlaceOrder;
using POC.Tests.Fakes;
using System.Collections.Generic;
using POC.Modules.Domain.Enums;
using POC.Modules.InputPorts.Order;

namespace POC.Tests.IntegrationTests.Orders
{
    public class OrdersIntegrationTests : Notifiable
    {
        [Test]
        public void OrderTests_PlaceOrder_ReturnOrderNumber()
        {
            PlaceOrderUseCase _placeOrder = new PlaceOrderUseCase(
                new FakeCustomerReadOnlyRepository(),               
                new FakeOrderWriteRepository(),
                new FakeProductReadOnlyRepository(),
                new FakeKafkaProducer());

            
            Guid customerId = Guid.NewGuid();
            
            OrderInput orderInput = new OrderInput
            {
                OrderId = Guid.NewGuid(), 
            };

            List<OrderItemInput> listOrderItem = new List<OrderItemInput>
            {
                new OrderItemInput("Coke", "Descripition", null, 10, 5, EAreas.Drink)
            };

            orderInput.OrderProductItem = listOrderItem;

           

            var placeOrderInput = new OrderInput()
            { 
                CustomerId = customerId, 
                OrderProductItem = listOrderItem
            };         

            string order = _placeOrder.Execute(placeOrderInput);

            AddNotifications(_placeOrder.Notifications);

            Assert.AreEqual(true, !Invalid);
        }
    }
}

using Flunt.Notifications;
using System.Linq;
using POC.Adapters.KafkaStreaming.Producer;
using POC.Modules.Application.Abstractions.Commands;
using POC.Modules.Application.Abstractions.Queries;
using POC.Modules.Domain.Entities;
using System;
using POC.Modules.InputPorts.Order;

namespace POC.Modules.Application.Commands.PlaceOrder
{
    public class PlaceOrderUseCase : Notifiable, IPlaceOrderUseCase
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly IProductReadOnlyRepository _productReadOnlyRepository;
        private readonly IOrderWriteRepository _orderWriteOnlyRepository;        
        private readonly IKafkaAdapter _kafkaAdapter;
       
        private Order _order;

        public PlaceOrderUseCase(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOrderWriteRepository orderWriteOnlyRepository,
            IProductReadOnlyRepository productReadOnlyRepository,
            IKafkaAdapter kafkaAdapter)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _orderWriteOnlyRepository = orderWriteOnlyRepository;
            _productReadOnlyRepository = productReadOnlyRepository;
            _kafkaAdapter = kafkaAdapter;
        }
        
        
        public string Execute(OrderInput order)
        {            
            var _customer = _customerReadOnlyRepository.Get(order.CustomerId);

            if (_customer == null)
            {
                var notification = new Notification("Client", "Client dosen't exist");              
                return notification.Message;
            }
                
            if (_customer.Invalid)
            {
                AddNotification("Client", "Error in client data: ");
                return _customer.Notifications.FirstOrDefault().Message;
            }


            //Todo Make a Mapper
            _order = new Order(_customer);

            foreach (var item in order.OrderProductItem)
            {
                var productExist = _productReadOnlyRepository.GetByNameAndArea(item.Title);
               
                if (productExist == null)
                {
                    AddNotification("Order", "Error identified in data: ");
                    return _order.Notifications.FirstOrDefault().Message;                  
                }

                _order.AddItem(productExist, item.Quantity, item.EAreas);

                if (_order.Invalid)
                {
                    AddNotification("Order", "Error identified in data: ");
                    return _order.Notifications.FirstOrDefault().Message;
                }
            }

            string orderId;
            try
            {
                orderId = _orderWriteOnlyRepository.PlaceOrder(_order);

               
                foreach (var item in _order.Itens)
                {
                    var OrderItentInput = new PlaceOrderItentInput() { 
                        OrderId = new Guid(orderId),
                        OrderProductItem = new OrderItemInput() 
                        { 
                            Description = item.Product.Description ,
                            EAreas = item.EAreas,
                            Price = item.Product.Price,
                            Quantity = item.Quantity,
                            Title = item.Product.Title,
                            Id = item.Id
                            
                        }  
                    };

                    _kafkaAdapter.Produce(OrderItentInput);
                }               
            }
            catch
            {
                throw;
            }

            return $"Order number: {orderId} - status: Processing";
        
        }
    
        

    }
}

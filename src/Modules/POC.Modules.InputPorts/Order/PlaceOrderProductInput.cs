using Flunt.Notifications;
using POC.Modules.Domain.Entities;
using POC.Modules.Domain.Enums;
using System;
using System.Collections.Generic;

namespace POC.Modules.InputPorts.Order
{
    
    public class OrderInput
    {
        public Guid CustomerId { get; set; }

        public Guid OrderId { get; set; }

        public EOrderStatus Status { get; set; }

        public List<OrderItemInput> OrderProductItem { get; set; }

    }

    public class OrderItemInput
    {
        public OrderItemInput(string title, string description, string image, decimal price, int quantity, EAreas eAreas)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            Quantity = quantity;
            EAreas = eAreas;
        }

        public OrderItemInput()
        {

        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public EAreas EAreas { get; set; }
        public Guid Id { get; set; }

    }
}

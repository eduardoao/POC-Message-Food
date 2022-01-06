using Flunt.Notifications;
using POC.Modules.Domain.Enums;
using System;

namespace POC.Modules.Domain.Entities
{
    public class OrderItem : Notifiable, IEntity
    {
        public OrderItem(Product product, int quantity, EAreas eAreas)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity = quantity;
            EAreas = eAreas;

            if (product.StockQuantity < quantity)
            {
                AddNotification("Quant", "Product empty");
            }            
        }

        public OrderItem()
        {

        }     
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Guid Id { get;  set; }

        public EAreas EAreas { get; private set; }
    }
}

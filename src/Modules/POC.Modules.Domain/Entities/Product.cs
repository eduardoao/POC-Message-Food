﻿using System;

namespace POC.Modules.Domain.Entities
{
    public class Product : IEntity
    {
        public Product(string title, string description, string image, decimal price, int stockQuantity = 0)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public Product()
        {

        }        
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public Guid Id { get;  set; }

        public void WidthdrawStockQuantity(int quantity)
        {
            StockQuantity -= quantity;
        }

    }
}

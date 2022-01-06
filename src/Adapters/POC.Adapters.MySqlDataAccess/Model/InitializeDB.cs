using POC.Adapters.MySqlDataAccess.Context;
using POC.Modules.Domain.Entities;
using POC.Modules.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace POC.Adapters.MySqlDataAccess.Model
{
    public static class InitializeDB
    {
        public static void Initialize(MySqlContext context)
        {
            context.Database.EnsureCreated();
            // Find for customer
            if (context.Customers.Any()) return;
            
            var name = new NameVo("Oliveira", "Eduardo");
            var cpf = new CpfVo("25275838816");
            var email = new EmailVo("eoalcantara@gmail.com");
            var _customer = new Customer(name, cpf, email, "11-5555-5555");
            var address = new Address("Rua Dom Bosco", 30, "Casa", "Centro", "SP", "Brazil");
            
            _customer.AddAddress(address);
            _customer.Id =  new System.Guid("8e2911be-bc52-490e-8769-a90f1b47b9fd");
            // Customer Added
            context.Customers.Add(_customer);

            // Find for Products 
            if (context.Products.Any()) return;

            var listProduct = new List<Product>() {
                new Product("Fries", "Fries", "image", 12.5M, 100),
                new Product("Grill", "Grill", "image", 43.5M, 100),
                new Product("Salad", "Salad", "", 15.5M, 100),
                new Product("Coke", "Coke", "", 23.5M, 100),
                new Product("Desert", "Desert", "", 53.5M, 100)
            };


            // Product Added
            foreach (Product product in listProduct)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }

    }
}

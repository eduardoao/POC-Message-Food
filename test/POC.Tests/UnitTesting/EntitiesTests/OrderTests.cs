using Flunt.Notifications;
using NUnit.Framework;
using POC.Modules.Domain.Entities;
using POC.Modules.Domain.Enums;
using POC.Modules.Domain.ValueObjects;

namespace POC.Tests.UnitTesting.EntitiesTests
{
    public class OrderTests : Notifiable
    {

        private Product _burger;
        private Product _drink;
        private Product _desert;
        private Customer _customer;
        private Order _order;

        [SetUp]
        public void Setup()
        {
            //Simular dados
            var name = new NameVo("Eduardo", "Oliveira");
            var cpf = new CpfVo("25275838816");
            var email = new EmailVo("eoalcantara@gmail.com");

            _burger = new Product("X-Burger", "X-Burger", "X-Burger.jpg", 10M, 10);
            _drink = new Product("CokeM-Coke", "CokeM-Coke", "CokeM-Coke.jpg", 5M, 10);
            _desert = new Product("Cookie", "Cookie", "Cookie.jpg", 50M, 10);

            _customer = new Customer(name, cpf, email, "11-5555-5555");
            _order = new Order(_customer);
        }


        [Test]
        public void OrderTests_CreateOrder_WhenValidReturnTrue()
        {
            Assert.AreEqual(true, _order.Valid);
        }

        [Test]
        public void OrderTests_CreateOrder_WhenCreatedStatusIsCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [Test]
        public void OrderTests_CreateOrder_OrderItemMustBe2()
        {
            _order.AddItem(_desert, 5, EAreas.Desert);
            _order.AddItem(_burger, 5, EAreas.Desert);

            Assert.AreEqual(2, _order.Itens.Count);
        }

        [Test]
        public void OrderTests_AddItem_ShouldSubtract5FromStock()
        {
            _order.AddItem(_desert, 5, EAreas.Desert);

            Assert.AreEqual(5, _desert.StockQuantity);
        }

        [Test]
        public void OrderTests_CreateOrder_ShouldHave2ShippingsIfHigherThan5()
        {
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.AddItem(_drink, 1, EAreas.Desert);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }
    }
}

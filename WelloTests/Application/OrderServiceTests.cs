using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Wello.Application;
using Wello.Data.Interfaces;
using Wello.Data.Models;

namespace WelloTests.Application
{
    [TestFixture]
    public class OrderServiceTests
    {
        private OrderService _orderService;
        private Mock<ICoffeeRepository> _coffeeRepository;

        [SetUp]
        public void Setup()
        {
            _coffeeRepository = new Mock<ICoffeeRepository>();
            _orderService = new OrderService(_coffeeRepository.Object);
        }

        [Test]
        public void CalculateOrderTotal_ShouldThrowException_WhenOrderHasNoCoffee()
        {
            _coffeeRepository.Setup(c => c.GetByOrderId(It.IsAny<int>())).Returns(new List<CoffeeModel>());

            Assert.Throws<ArgumentOutOfRangeException>(() => _orderService.CalculateOrderTotal(0));
        }

        [Test]
        public void CalculateOrderTotal_ShouldReturnTotal_WhenOrderContainsCoffee()
        {
            const int orderId = 1;
            var coffeeModel = new CoffeeModel
            {
                AmountOfCream = 3,
                AmountOfSugar = 3,
                OrderId = orderId,
                Size = "large"
            };

            _coffeeRepository.Setup(c => c.GetByOrderId(1)).Returns(new List<CoffeeModel>{coffeeModel});

            var amount = _orderService.CalculateOrderTotal(orderId);

            Assert.That(amount, Is.GreaterThan(0));
        }
    }
}

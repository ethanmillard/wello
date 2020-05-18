using System;
using NUnit.Framework;
using Wello.Data.Repositories;

namespace WelloTests.Data.Repositories
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        private OrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            _orderRepository = new OrderRepository();
        }

        [Test]
        public void Create_ShouldCreateNewOrderWithIdOfOne_NoOrderExistsAlready()
        {
            var order = _orderRepository.Create();
            Assert.That(order.Id, Is.EqualTo(1));
        }

        [Test]
        public void Create_ShouldCreateNewOrderWithIdOfTwo_WhenOneOrderAlreadyExists()
        {
            _orderRepository.Create();
            var order2 = _orderRepository.Create();
            Assert.That(order2.Id, Is.EqualTo(2));
        }

        [Test]
        public void Find_ShouldFindOrder_WhenOrderExists()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _orderRepository.Find(0));
        }

        [Test]
        public void Find_ShouldThrowException_WhenOrderDoesNotExist()
        {
            var order = _orderRepository.Create();

            var foundOrder = _orderRepository.Find(order.Id);
            Assert.That(foundOrder.Id, Is.EqualTo(order.Id));
        }

        [Test]
        public void Update_ShouldThrowException_WhenOrderDoesNotExist()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _orderRepository.Update(0, 0, 0));
        }

        [Test]
        public void Update_ShouldUpdateOrder_WhenOrderExists()
        {
            const int expectedAmountDue = 2;
            const int expectedAmountPaid = 3;

            var order = _orderRepository.Create();

            order = _orderRepository.Update(order.Id, expectedAmountDue, expectedAmountPaid);

            Assert.That(order.AmountDue, Is.EqualTo(expectedAmountDue));
            Assert.That(order.AmountPaid, Is.EqualTo(expectedAmountPaid));
        }
    }
}
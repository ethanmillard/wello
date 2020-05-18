using System;
using NUnit.Framework;
using Wello.Data.Repositories;

namespace WelloTests.Data.Repositories
{
    [TestFixture]
    public class CoffeeRepositoryTests
    {
        private CoffeeRepository _coffeeRepository;

        [SetUp]
        public void SetUp()
        {
            _coffeeRepository = new CoffeeRepository();
        }

        [Test]
        public void Create_ShouldCreateNewCoffeeWithIdOfOne_WhenNoCoffeeHasBeenCreatedBefore()
        {
            var coffee = _coffeeRepository.Create(0, "size", 0, 0);
            Assert.That(coffee.Id, Is.EqualTo(1));
        }

        [Test]
        public void Create_ShouldCreateNewCoffeeWithIdOfTwo_WhenOneCoffeeAlreadyExists()
        {
            _coffeeRepository.Create(0, "size", 0, 0);
            var coffee2 = _coffeeRepository.Create(0, "size", 0, 0);
            Assert.That(coffee2.Id, Is.EqualTo(2));
        }

        [Test]
        public void GetByOrderId_ShouldReturnAllCoffeeWithTheSameOrderId_WhenCoffeeHaveTheSameOrderId()
        {
            const int orderId = 1;

            var coffee1 = _coffeeRepository.Create(orderId, "size", 0, 0);
            var coffee2 = _coffeeRepository.Create(0, "size", 0, 0);
            var coffee3 = _coffeeRepository.Create(orderId, "size", 0, 0);

            var coffees = _coffeeRepository.GetByOrderId(orderId);

            Assert.That(coffees, Contains.Item(coffee1), "Should contain coffee1");
            Assert.That(coffees, !Contains.Item(coffee2), "Should not contain coffee2");
            Assert.That(coffees, Contains.Item(coffee3), "Should contain coffee3");
        }

        [Test]
        public void Update_ShouldThrowException_WhenNoCoffeeIsFound()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _coffeeRepository.Update(0, 0, 0));
        }

        [Test]
        public void Update_ShouldUpdateCoffee_WhenCoffeeExists()
        {
            const int expectedCream = 2;
            const int expectedSugar = 3;

            var coffee = _coffeeRepository.Create(0, "size", 0, 0);

            coffee = _coffeeRepository.Update(coffee.Id, expectedCream, expectedSugar);

            Assert.That(coffee.AmountOfCream, Is.EqualTo(expectedCream));
            Assert.That(coffee.AmountOfSugar, Is.EqualTo(expectedSugar));
        }
    }
}
using System;
using System.Linq;
using Wello.Data.Interfaces;

namespace Wello.Application
{
    /// <summary>
    /// Service class for an order.
    /// </summary>
    public class OrderService : IOrderService
    {
        private const int CostOfSmallCoffee = 1;
        private const int CostOfMediumCoffee = 2;
        private const int CostOfLargeCoffee = 3;

        private const double CostOfCream = .25;
        private const double CostOfSugar = .5;
        private readonly ICoffeeRepository _coffeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="coffeeRepository"></param>
        public OrderService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        /// <summary>
        /// Calculates the total cost of an order.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order.</param>
        /// <returns>The total cost of the order.</returns>
        public double CalculateOrderTotal(int orderId)
        {
            var coffees = _coffeeRepository.GetByOrderId(orderId);
            if (!coffees.Any())
            {
                throw new ArgumentOutOfRangeException("There is no coffee added to the order. Please add coffee before attempting to purchase your order.");
            }

            var totalSmalls = coffees.Count(c => c.Size == "small");
            var totalMediums = coffees.Count(c => c.Size == "medium");
            var totalLarges = coffees.Count(c => c.Size == "large");

            var totalCream = coffees.Sum(c => c.AmountOfCream);
            var totalSugar = coffees.Sum(c => c.AmountOfSugar);

            return totalSmalls * CostOfSmallCoffee + totalMediums * CostOfMediumCoffee + totalLarges * CostOfLargeCoffee + totalCream * CostOfCream + totalSugar * CostOfSugar;
        }
    }
}
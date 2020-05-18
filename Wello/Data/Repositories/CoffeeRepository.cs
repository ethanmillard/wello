using System;
using System.Collections.Generic;
using System.Linq;
using Wello.Data.Interfaces;
using Wello.Data.Models;

namespace Wello.Data.Repositories
{
    /// <summary>
    /// A repository for coffee.
    /// </summary>
    public class CoffeeRepository : ICoffeeRepository
    {
        /// <summary>
        /// Static storage of coffees during the lifespan of the application.
        /// </summary>
        private readonly Dictionary<int, CoffeeModel> _coffees = new Dictionary<int, CoffeeModel>();

        /// <summary>
        /// Creates a new <see cref="CoffeeModel"/>.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order the coffee is for.</param>
        /// <param name="size">The size of the coffee.</param>
        /// <param name="amountOfCream">The amount of cream for the coffee.</param>
        /// <param name="amountOfSugar">The amount of sugar for the coffee.</param>
        /// <returns>A newly created <see cref="CoffeeModel"/>.</returns>
        public CoffeeModel Create(int orderId, string size, int amountOfCream, int amountOfSugar)
        {
            var lastKey = 0;
            if (_coffees.Any())
            {
                lastKey = _coffees.Keys.Max();
            }

            var coffeeModel = new CoffeeModel
            {
                AmountOfCream = amountOfCream,
                AmountOfSugar = amountOfSugar,
                OrderId = orderId,
                Size = size,
                Id = lastKey + 1
            };

            _coffees.Add(coffeeModel.Id, coffeeModel);

            return coffeeModel;
        }

        /// <summary>
        /// Updates an <see cref="CoffeeModel"/>.
        /// </summary>
        /// <param name="coffeeId">The unique identifier of the coffee.</param>
        /// <param name="amountOfCream">The amount of cream for the coffee.</param>
        /// <param name="amountOfSugar">The amount of sugar for the coffee.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no <see cref="CoffeeModel"/> matches the unique identifier.</exception>
        /// <returns>A newly created <see cref="CoffeeModel"/>.</returns>
        public CoffeeModel Update(int coffeeId, int amountOfCream, int amountOfSugar)
        {
            if (!_coffees.TryGetValue(coffeeId, out var coffee))
            {
                throw new ArgumentOutOfRangeException(nameof(CoffeeModel), $"No coffee with the Id of '{coffeeId}'");
            }

            coffee.AmountOfCream = amountOfCream;
            coffee.AmountOfSugar = amountOfSugar;

            return coffee;
        }

        /// <summary>
        /// Deletes an <see cref="CoffeeModel"/> based on the unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="CoffeeModel"/> to delete.</param>
        public void Delete(int id)
        {
            _coffees.Remove(id);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="CoffeeModel"/>s by order id.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>A list of <see cref="CoffeeModel"/>s.</returns>
        public List<CoffeeModel> GetByOrderId(int id)
        {
            return _coffees.Where(c => c.Value.OrderId == id).Select(c => c.Value).ToList();
        }
    }
}
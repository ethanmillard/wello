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
        /// Finds an <see cref="CoffeeModel"/> based on the unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of an <see cref="CoffeeModel"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no coffee matches the unique identifier.</exception>
        /// <returns>An <see cref="CoffeeModel"/>.</returns>
        public CoffeeModel Find(int id)
        {
            if (!_coffees.TryGetValue(id, out var coffee))
            {
                throw new ArgumentOutOfRangeException(nameof(CoffeeModel), $"No coffee with the Id of '{id}'");
            }

            return coffee;
        }

        /// <summary>
        /// Creates a new <see cref="CoffeeModel"/>.
        /// </summary>
        /// <returns>A newly created <see cref="CoffeeModel"/>.</returns>
        public CoffeeModel Create(CoffeeModel coffeeModel)
        {
            var lastKey = 0;
            if (_coffees.Any())
            {
                lastKey = _coffees.Keys.Max();
            }

            coffeeModel.Id = lastKey + 1;

            _coffees.Add(coffeeModel.Id, coffeeModel);

            return coffeeModel;
        }

        /// <summary>
        /// Updates an <see cref="CoffeeModel"/>.
        /// </summary>
        /// <param name="coffeeModel">The <see cref="CoffeeModel"/> containing the updated properties.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no <see cref="CoffeeModel"/> matches the unique identifier.</exception>
        public void Update(CoffeeModel coffeeModel)
        {
            if (!_coffees.TryGetValue(coffeeModel.Id, out var coffee))
            {
                throw new ArgumentOutOfRangeException(nameof(CoffeeModel), $"No coffee with the Id of '{coffeeModel.Id}'");
            }
               
            coffee.AmountOfCream = coffeeModel.AmountOfCream;
            coffee.AmountOfSugar = coffeeModel.AmountOfSugar;
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
using System;
using Wello.Data.Models;

namespace Wello.Data.Interfaces
{
    /// <summary>
    /// A repository for coffee.
    /// </summary>
    public interface ICoffeeRepository
    {
        /// <summary>
        /// Finds an <see cref="CoffeeModel"/> based on the unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of an <see cref="CoffeeModel"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no coffee matches the unique identifier.</exception>
        /// <returns>An <see cref="CoffeeModel"/>.</returns>
        CoffeeModel Find(int id);

        /// <summary>
        /// Creates a new <see cref="CoffeeModel"/>.
        /// </summary>
        /// <returns>A newly created <see cref="CoffeeModel"/>.</returns>
        CoffeeModel Create(CoffeeModel coffeeModel);

        /// <summary>
        /// Updates an <see cref="CoffeeModel"/>.
        /// </summary>
        /// <param name="coffeeModel">The <see cref="CoffeeModel"/> containing the updated properties.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no <see cref="CoffeeModel"/> matches the unique identifier.</exception>
        void Update(CoffeeModel coffeeModel);

        /// <summary>
        /// Deletes an <see cref="CoffeeModel"/> based on the unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="CoffeeModel"/> to delete.</param>
        void Delete(int id);
    }
}
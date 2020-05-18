using System;
using System.Collections.Generic;
using Wello.Data.Models;

namespace Wello.Data.Interfaces
{
    /// <summary>
    /// A repository for coffee.
    /// </summary>
    public interface ICoffeeRepository
    {
        /// <summary>
        /// Deletes an <see cref="CoffeeModel"/> based on the unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="CoffeeModel"/> to delete.</param>
        void Delete(int id);

        /// <summary>
        /// Retrieves a collection of <see cref="CoffeeModel"/>s by order id.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>A list of <see cref="CoffeeModel"/>s.</returns>
        List<CoffeeModel> GetByOrderId(int id);

        /// <summary>
        /// Creates a new <see cref="CoffeeModel"/>.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order the coffee is for.</param>
        /// <param name="size">The size of the coffee.</param>
        /// <param name="amountOfCream">The amount of cream for the coffee.</param>
        /// <param name="amountOfSugar">The amount of sugar for the coffee.</param>
        /// <returns>A newly created <see cref="CoffeeModel"/>.</returns>
        CoffeeModel Create(int orderId, string size, int amountOfCream, int amountOfSugar);

        /// <summary>
        /// Updates an <see cref="CoffeeModel"/>.
        /// </summary>
        /// <param name="coffeeId">The unique identifier of the coffee.</param>
        /// <param name="amountOfCream">The amount of cream for the coffee.</param>
        /// <param name="amountOfSugar">The amount of sugar for the coffee.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no <see cref="CoffeeModel"/> matches the unique identifier.</exception>
        /// <returns>A newly created <see cref="CoffeeModel"/>.</returns>
        CoffeeModel Update(int coffeeId, int amountOfCream, int amountOfSugar);
    }
}
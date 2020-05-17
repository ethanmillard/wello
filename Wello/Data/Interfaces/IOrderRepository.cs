using System;
using Wello.Data.Models;

namespace Wello.Data.Interfaces
{
    /// <summary>
    /// A repository for an order.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Finds an <see cref="OrderModel"/> based on the unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of an <see cref="OrderModel"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no order matches the unique identifier.</exception>
        /// <returns>An <see cref="OrderModel"/>.</returns>
        OrderModel Find(int id);

        /// <summary>
        /// Creates a new <see cref="OrderModel"/>.
        /// </summary>
        /// <returns>A newly created <see cref="OrderModel"/>.</returns>
        OrderModel Create();

        /// <summary>
        /// Updates an <see cref="OrderModel"/>.
        /// </summary>
        /// <param name="orderModel">The <see cref="OrderModel"/> containing the updated properties.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no order matches the unique identifier.</exception>
        void Update(OrderModel orderModel);

        /// <summary>
        /// Deletes an <see cref="OrderModel"/> based on the unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to delete.</param>
        void Delete(int id);
    }
}
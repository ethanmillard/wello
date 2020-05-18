using System;
using System.Collections.Generic;
using System.Linq;
using Wello.Data.Interfaces;
using Wello.Data.Models;

namespace Wello.Data.Repositories
{
    /// <summary>
    /// A repository for an order.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Static storage of orders during the lifespan of the application.
        /// </summary>
        private readonly Dictionary<int, OrderModel> _orders = new Dictionary<int, OrderModel>();

        /// <summary>
        /// Finds an <see cref="OrderModel"/> based on the unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of an <see cref="OrderModel"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no order matches the unique identifier.</exception>
        /// <returns>An <see cref="OrderModel"/>.</returns>
        public OrderModel Find(int id)
        {
            if (!_orders.TryGetValue(id, out var order))
            {
                throw new ArgumentOutOfRangeException(nameof(OrderModel), $"No order with the Id of '{id}'");
            }

            return order;
        }

        /// <summary>
        /// Creates a new <see cref="OrderModel"/>.
        /// </summary>
        /// <returns>A newly created <see cref="OrderModel"/>.</returns>
        public OrderModel Create()
        {
            var lastKey = 0;
            if (_orders.Any())
            {
                lastKey = _orders.Keys.Max();
            }

            var order = new OrderModel
            {
                Id = lastKey + 1
            };

            _orders.Add(order.Id, order);

            return order;
        }

        /// <summary>
        /// Updates an <see cref="OrderModel"/>.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order.</param>
        /// <param name="amountDue">The total amount due for the order.</param>
        /// <param name="amountPaid">The amount that has currently been paid on the order.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when no order matches the unique identifier.</exception>
        /// <returns>The <see cref="OrderModel"/>.</returns>
        public OrderModel Update(int orderId, double amountDue, double amountPaid)
        {
            if (!_orders.TryGetValue(orderId, out var order))
            {
                throw new ArgumentOutOfRangeException(nameof(OrderModel), $"No order with the Id of '{orderId}'");
            }

            order.AmountDue = amountDue;
            order.AmountPaid = amountPaid;

            return order;
        }
    }
}
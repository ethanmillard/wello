namespace Wello.Application
{
    /// <summary>
    /// Service class for an order.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Calculates the total cost of an order.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order.</param>
        /// <returns>The total cost of the order.</returns>
        double CalculateOrderTotal(int orderId);
    }
}
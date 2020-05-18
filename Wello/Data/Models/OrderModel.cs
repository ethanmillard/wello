namespace Wello.Data.Models
{
    /// <summary>
    /// A model representing an order.
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the amount paid for the order.
        /// </summary>
        public double AmountPaid { get; set; }

        /// <summary>
        /// Gets or sets the amount due for the complete coffee order.
        /// </summary>
        public double AmountDue { get; set; }
    }
}
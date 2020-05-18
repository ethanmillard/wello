using System.Text.Json.Serialization;

namespace Wello.Api.Resources
{
    /// <summary>
    /// A Resource representing an order.
    /// </summary>
    public class OrderResource
    {
        /// <summary>
        /// Gets or sets the unique identifier of the order.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the amount due for the order.
        /// </summary>
        [JsonPropertyName("amountDue")]
        public double AmountDue { get; set; }

        /// <summary>
        /// Gets or sets the amount paid for the order.
        /// </summary>
        [JsonPropertyName("amountPaid")]
        public double AmountPaid { get; set; }
    }
}
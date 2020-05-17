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
    }
}
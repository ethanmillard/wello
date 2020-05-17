using System.Text.Json.Serialization;

namespace Wello.Api.Resources
{
    /// <summary>
    /// A resource representing a coffee.
    /// </summary>
    public class CoffeeResource
    {
        /// <summary>
        /// Gets or sets the unique identifier of the coffee.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the order the coffee belongs to.
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the size of the coffee.
        /// </summary>
        [JsonPropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the amount of sugar for the coffee.
        /// </summary>
        [JsonPropertyName("amountOfSugar")]
        public int AmountOfSugar { get; set; }

        /// <summary>
        /// Gets or sets the amount of cream for the coffee.
        /// </summary>
        [JsonPropertyName("amountOfCream")]
        public int AmountOfCream { get; set; }
    }
}
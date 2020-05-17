namespace Wello.Data.Models
{
    /// <summary>
    /// A model representing a coffee.
    /// </summary>
    public class CoffeeModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the coffee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the order the coffee belongs to.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the size of the coffee.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the amount of sugar for the coffee.
        /// </summary>
        public int AmountOfSugar { get; set; }

        /// <summary>
        /// Gets or sets the amount of cream for the coffee.
        /// </summary>
        public int AmountOfCream { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace InternetStoreTestTask.Models.StorageModels
{
    /// <summary xml:lang = "en">
    /// User's order
    /// </summary>
    public class Order
    {
        /// <summary xml:lang = "en">
        /// Unique key
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary xml:lang = "en">
        /// Unique key of User entity
        /// </summary>
        public long UserId { get; set; }

        /// <summary xml:lang = "en">
        /// User field
        /// </summary>
        public User User { get; set; }

        /// <summary xml:lang = "en">
        /// Date of order
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary xml:lang = "en">
        /// Price of order
        /// </summary>
        public decimal Price { get; set; }

        /// <summary xml:lang = "en">
        /// List of products in Order
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
    }
}

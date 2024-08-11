using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetStoreTestTask.Models.StorageModels
{
    /// <summary xml:lang = "en">
    /// Product of internet store
    /// </summary>
    public class Product: IEntity
    {
        /// <summary xml:lang = "en">
        /// Unique key
        /// </summary>
        public long Id { get; set; }

        /// <summary xml:lang = "en">
        /// Name of product
        /// </summary>
        public string Name { get; set; }

        /// <summary xml:lang = "en">
        /// Unique key of ProductType entity
        /// </summary>
        public long? ProductTypeId { get; set; }

        /// <summary xml:lang = "en">
        /// ProductType field
        /// </summary>
        public ProductType? ProductType { get; set; }

        /// <summary xml:lang = "en">
        /// Price of product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary xml:lang = "en">
        /// Count of product
        /// </summary>
        public int Count { get; set; }

        /// <summary xml:lang = "en">
        /// List of purchase
        /// </summary>
        public IEnumerable<Purchase> Purchases { get; set; }

        /// <summary xml:lang = "en">
        /// List of product orders
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }
    }
}
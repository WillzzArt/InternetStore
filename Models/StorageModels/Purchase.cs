using System.ComponentModel.DataAnnotations.Schema;

namespace InternetStoreTestTask.Models.StorageModels
{
    /// <summary xml:lang = "en">
    /// Purchase of order
    /// </summary>
    public class Purchase
    {
        /// <summary xml:lang = "en">
        /// Unique key of Oreder entity
        /// </summary>
        public long OrderId { get; set; }

        /// <summary xml:lang = "en">
        /// Order field
        /// </summary>
        public Order Order { get; set; }

        /// <summary xml:lang = "en">
        /// Unique key of Product entity
        /// </summary>
        public long ProductId { get; set; }

        /// <summary xml:lang = "en">
        /// Product field
        /// </summary>
        public Product Product { get; set; }

        /// <summary xml:lang = "en">
        /// Count of purchase
        /// </summary>
        public int Count { get; set; }
    }
}

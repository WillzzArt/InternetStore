using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetStoreTestTask.Models.StorageModels
{
    /// <summary xml:lang = "en">
    /// Type of product
    /// </summary>
    public class ProductType: IEntity
    {
        /// <summary xml:lang = "en">
        /// Unique key
        /// </summary>
        public long Id { get; set; }

        /// <summary xml:lang = "en">
        /// Name of type
        /// </summary>
        public string Type { get; set; }
    }
}

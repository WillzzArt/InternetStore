using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetStoreTestTask.Models.StorageModels
{
    /// <summary xml:lang = "en">
    /// The User of the internet store
    /// </summary>
    public class User: IEntity
    {
        /// <summary xml:lang = "en">
        /// Unique key
        /// </summary>
        public long Id { get; set; }

        /// <summary xml:lang = "en">
        /// Fullname of User
        /// </summary>
        public string Fullname { get; set; }

        /// <summary xml:lang = "en">
        /// Email of user
        /// </summary>
        public string? Email { get; set; }

        /// <summary xml:lang = "en">
        /// Age of user
        /// </summary>
        public int? Age { get; set; }
    }
}

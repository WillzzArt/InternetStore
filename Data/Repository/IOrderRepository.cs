namespace InternetStoreTestTask.Data.Repository
{
    /// <summary>
    /// Repository for Order entity
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary xml:lang = "en">
        /// Saves the list of orders from an xml file
        /// </summary>
        /// <param name="xmlPath">The path to the xml file</param>
        /// <returns></returns>
        Task SaveOrderFromXml(string xmlPath);
    }
}

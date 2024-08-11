namespace InternetStoreTestTask.Data.Repository
{
    public interface IOrderRepository
    {
        Task SaveOrderFromXml(string xmlPath);
    }
}

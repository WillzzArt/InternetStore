using System.Xml.Serialization;

namespace InternetStoreTestTask.Helpers
{
    public static class XmlSerializerHelper
    {
        public static T? Deserialize<T>(string filePath) where T : class, new()
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));

            var serializer = new XmlSerializer(typeof(T));

            using (var sr = new StreamReader(filePath))
            {
                try
                {
                    return serializer.Deserialize(sr) as T;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }
            }
        }
    }
}

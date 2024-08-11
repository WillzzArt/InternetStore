using System.Xml.Serialization;

namespace InternetStoreTestTask.Models.XMLModels
{
    [XmlRoot("orders")]
    public class OrderRootXML
    {
        /*[XmlArray("orders")]
        [XmlArrayItem("order", typeof(OrderXML))]*/
        [XmlElement("order")]
        public OrderXML[] Orders { get; set; }
    }
}

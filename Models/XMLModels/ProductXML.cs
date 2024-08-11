using System.Xml.Serialization;

namespace InternetStoreTestTask.Models.XMLModels
{
    public class ProductXML
    {
        [XmlElement("quantity")]
        public int Quantity { get; set; }

        [XmlElement("name")]
        public string Name {  get; set; }
        
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}

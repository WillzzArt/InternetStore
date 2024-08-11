using System.Xml.Serialization;

namespace InternetStoreTestTask.Models.XMLModels
{
    public class OrderXML
    {
        [XmlElement("no")]
        public int Id { get; set; }

        [XmlElement("reg_date")]
        public string Date { get; set; }

        [XmlElement("sum")]
        public decimal Sum { get; set; }

        [XmlElement("product")]
        public ProductXML[] Product { get; set; }

        [XmlElement("user")]
        public UserXML User { get; set; }
    }
}

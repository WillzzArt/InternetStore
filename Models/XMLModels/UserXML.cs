using System.Xml.Serialization;

namespace InternetStoreTestTask.Models.XMLModels
{
    public class UserXML
    {
        [XmlElement("fio")]
        public string FIO { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }
    }
}

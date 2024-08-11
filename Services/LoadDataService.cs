using InternetStoreTestTask.Helpers;
using InternetStoreTestTask.Models.XMLModels;
using System.Xml.Linq;

namespace InternetStoreTestTask.Services
{
    public class LoadDataService
    {

        public void Load()
        {
            //var orderDb = new Order();

            var orders = XmlSerializerHelper.Deserialize<OrderRootXML>("Order.xml");

            if (orders == null) throw new NullReferenceException();


            /*var orders = _order.Element("orders");

            if (orders != null)
            {
                foreach (var order in orders.Elements("order"))
                {
                    Console.WriteLine(order.Element("reg_date")?.Value);

                    if (order.Element("reg_date") != null)
                    {
                        var data = DateOnly.ParseExact(order.Element("reg_date").Value, "");
                    }
                    
                }
            }*/
        }
    }
}

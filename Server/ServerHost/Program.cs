using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(Service.Database), new Uri("http://localhost:8733/Design_Time_Addresses/Service/Database/1"));
            //  serviceHost.AddServiceEndpoint(typeof(IDatabase), new BasicHttpBinding(), "");
            //  ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            //  behavior.HttpGetEnabled = true;
            //  serviceHost.Description.Behaviors.Add(behavior);
            //  serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            serviceHost.Open();

            Console.WriteLine("To exit press enter");
            Console.ReadKey();

            serviceHost.Close();

        }
    }
}

using System;
using System.ServiceModel;

using OrderService.Contracts;

namespace OrderService.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceBaseUri = new Uri("http://localhost:23352/");
            var host = new ServiceHost(typeof(OrderService), serviceBaseUri);

            var binding = new WSHttpBinding();

            host.AddServiceEndpoint(typeof(IOrderService), binding, "OrderService.svc");

            host.Open();
            
            Console.WriteLine("Press ENTER to shut down service.");
            Console.ReadLine();

            host.Close();
        }
    }
}

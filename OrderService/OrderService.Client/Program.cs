using System;
using System.Collections.Generic;

using OrderService.Contracts;

namespace OrderService.Client
{
    class Program
    {
        static void Main()
        {            
            using (var client = new OrderServiceClient())
            {
                bool finished;
                do
                {
                    var order = GenerateOrder(); // get a fake order

                    Console.WriteLine("Adding order.");
                    client.AddOrder(order);

                    Console.WriteLine("There are {0} order(s).", client.GetOrders().Count);

                    Console.WriteLine("Add another order? (Y/N)");
                    finished = Console.ReadLine() == "N";
                } while (!finished);
            }

            
            Console.WriteLine("Hit ENTER to quit.");
            Console.ReadLine();
        }

        private static Order GenerateOrder()
        {
            var customers = new List<string> { "Bhaumin", "James", "Emil", "Gage", "Jake", "Ben" };

            return new Order
                       {
                           CustomerName = customers.PickRandom(),
                           OrderItems =
                               new List<OrderLineItem>
                                   {
                                       new OrderLineItem
                                           {
                                               Quantity = 12,
                                               Sku = "SKU11111111"
                                           },
                                       new OrderLineItem
                                           {
                                               Quantity = 6,
                                               Sku = "SKU22222222"
                                           }
                                   }
                       };
        }
    }
}

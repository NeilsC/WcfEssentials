using System;
using System.Collections.Generic;
using System.ServiceModel;

using OrderService.Contracts;

namespace OrderService
{    
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            try
            {
                Console.WriteLine("Adding order for customer {0}", order.CustomerName);

                ValidateOrder(order);
         
                _orders.Add(order);
            }
            catch (ArgumentException ex)
            {
                throw new FaultException<ArgumentException>(ex);                
            }
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        private static void ValidateOrder(Order order)
        {
            if (string.IsNullOrEmpty(order.CustomerName))
            {
                throw new ArgumentException("CustomerName cannot be empty", "order");
            }
        }
    }
}

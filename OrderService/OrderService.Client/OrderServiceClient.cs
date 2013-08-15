using System.Collections.Generic;
using System.ServiceModel;

using OrderService.Contracts;

namespace OrderService.Client
{
    class OrderServiceClient : ClientBase<IOrderService>, IOrderService 
    {
        public void AddOrder(Order order)
        {
            Channel.AddOrder(order);
        }

        public List<Order> GetOrders()
        {
            return Channel.GetOrders();
        }
    }
}

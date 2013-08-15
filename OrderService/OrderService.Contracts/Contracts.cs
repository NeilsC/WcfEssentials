using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace OrderService.Contracts
{
    [DataContract]
    public class OrderLineItem
    {
        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }

    [DataContract]
    public class Order
    {
        [DataMember]
        public string CustomerName { get; set; }
        
        [DataMember]
        public List<OrderLineItem> OrderItems { get; set; }
    }

    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]    
        [FaultContract(typeof(ArgumentException))]
        void AddOrder(Order order);

        [OperationContract]
        List<Order> GetOrders();
    }
}
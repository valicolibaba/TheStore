using System.Collections.Generic;

namespace Store.Domain.OrderManagement
{
    public interface IOrderRepository
    {
        IList<Order> GetAllOrders();
        void AddOrder(Order order);
        void DeleteOrderById(int id);
    }
}
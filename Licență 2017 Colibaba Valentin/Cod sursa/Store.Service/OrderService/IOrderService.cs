using System.Collections.Generic;
using System.ServiceModel;
using Store.Service.OrderService.Data;

namespace Store.Service.OrderService
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        IEnumerable<Order> GetAllOrders();

        [OperationContract]
        string AddOrder(Order order);

        [OperationContract]
        int CreateCart(string email);

        [OperationContract]
        Cart GetUserCart(string email);

        [OperationContract]
        int AddProductToCart(int productId, string userEmail);

        [OperationContract]
        int UpdateUserCart(Cart cart);

        [OperationContract]
        IEnumerable<Order> GetOrdersForCustomer(int customerId);

        [OperationContract]
        string DeleteOrder(int id);

        [OperationContract]
        int DeleteProductFromCart(int productId, string userEmail);

        [OperationContract]
        int DeleteUserCart(string userEmail);
    }
}

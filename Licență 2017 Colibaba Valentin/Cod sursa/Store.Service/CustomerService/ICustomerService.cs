using System.Collections.Generic;
using System.ServiceModel;
using Store.Service.CustomerService.Data;
using Store.Service.OrderService.Data;

namespace Store.Service.CustomerService
{ 
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        string AddCustomer(Customer customer);

        [OperationContract]
        string UpdateCustomer(Customer customer);

        [OperationContract]
        Customer GetCustomerById(int id);

        [OperationContract]
        Customer GetCustomerByEmail(string email);

        [OperationContract]
        bool VerifyAccount(CustomerAccount customerAccount);

        [OperationContract]
        IEnumerable<Order> GetOrdersForCustomer(string firstName, string lastName);

        [OperationContract]
        string DeleteCustomerById(int id);
    }
}

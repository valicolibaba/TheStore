using System.Collections.Generic;
using Store.Domain.OrderManagement;

namespace Store.Domain.CustomerManagement
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAllCutCustomers();
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        IList<Order> GetOrdersForCustomers(string firstName, string lastName);
        void UpdateCustomer(Customer customer);
        void DeleteById(int id);
    }
}
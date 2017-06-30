using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using Store.Database;
using Order = Store.Domain.OrderManagement.Order;

namespace Store.Domain.CustomerManagement
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext storeContext;
        public CustomerRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public IList<Customer> GetAllCutCustomers()
        {
            return storeContext.Customers.ProjectToList<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            var customerDao = Mapper.Map<Database.Models.Customer>(customer);
            storeContext.Customers.Add(customerDao);
            storeContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var customerDao = Mapper.Map<Database.Models.Customer>(customer);
            storeContext.Customers.AddOrUpdate(customerDao);
            storeContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var customer = storeContext.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null) return;
            storeContext.Customers.Remove(customer);
            storeContext.SaveChanges();
        }

        public IList<Order> GetOrdersForCustomers(string firstName, string lastName)
        {
            var customerDto = storeContext.Customers.FirstOrDefault(x => x.LastName.Trim() == lastName.Trim()
                                                                          && x.FirstName.Trim() == firstName.Trim());
            return customerDto.Orders.Select(Mapper.Map<Order>).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            var customerDto = storeContext.Customers.SingleOrDefault(x => x.Id == id);
            return Mapper.Map<Customer>(customerDto);
        }
    }
}

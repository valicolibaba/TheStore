using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.Domain.CustomerManagement;
using Store.Service.CustomerService.Data;
using Store.Service.OrderService.Data;
using Customer = Store.Service.CustomerService.Data.Customer;

namespace Store.Service.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;


        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = customerRepository.GetAllCutCustomers().Select(Mapper.Map<Customer>);
            return customers;
        }

        public string AddCustomer(Customer customer)
        {
            var customerDomain = Mapper.Map<Domain.CustomerManagement.Customer>(customer);
            customerRepository.AddCustomer(customerDomain);
            return "Customer created!";
        }

        public Customer GetCustomerById(int id)
        {
            var domainCustomer = customerRepository.GetCustomerById(id);
            var customer = Mapper.Map<Customer>(domainCustomer);
            return customer;
        }

        public IEnumerable<Order> GetOrdersForCustomer(string firstName, string lastName)
        {
            var domainOrders = customerRepository.GetOrdersForCustomers(firstName, lastName);
            var orders = domainOrders.Select(Mapper.Map<Order>);
            return orders;
        }

        public string DeleteCustomerById(int id)
        {
            customerRepository.DeleteById(id);
            return "Customer deleted!";
        }

        public bool VerifyAccount(CustomerAccount customerAccount)
        {
            return
                customerRepository.GetAllCutCustomers()
                    .Any(x => x.Email == customerAccount.Email && x.Password == customerAccount.Password);
        }

        public Customer GetCustomerByEmail(string email)
        {
            var domainCustomer = customerRepository.GetAllCutCustomers().SingleOrDefault(x => x.Email == email);
            var customer = Mapper.Map<Customer>(domainCustomer);
            return customer;
        }

        public string UpdateCustomer(Customer customer)
        {
            var customerDomain = Mapper.Map<Domain.CustomerManagement.Customer>(customer);
            customerRepository.UpdateCustomer(customerDomain);
            return "Customer updated!";
        }
    }
}

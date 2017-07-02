using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using Store.Database;
using Store.Database.Models;

namespace Store.Domain.OrderManagement
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext storeContext;
        public OrderRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public IList<Order> GetAllOrders()
        {
            return storeContext.Orders.Select(Mapper.Map<Order>).ToList();
        }

        public void AddOrder(Order order)
        {
            var customerDto = storeContext.Customers.SingleOrDefault(x => x.Id == order.Customer.Id);
            var productOrdersDtos = order.Products.Select(product => storeContext.Products.SingleOrDefault(x => x.Id == product.Id)).ToList();
            var orderDto = Mapper.Map<Database.Models.Order>(order);
            orderDto.Customer = customerDto;
            orderDto.Products = productOrdersDtos;
            storeContext.Orders.AddOrUpdate(orderDto);
            storeContext.SaveChanges();
        }

        public void DeleteOrderById(int id)
        {
            var orderDto = storeContext.Orders.SingleOrDefault(x => x.Id == id);
            if (orderDto != null)
            {
                storeContext.Orders.Remove(orderDto);
                storeContext.SaveChanges();
            }
        }
    }
}

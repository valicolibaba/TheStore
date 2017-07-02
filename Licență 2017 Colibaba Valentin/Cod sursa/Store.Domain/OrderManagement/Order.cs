using System;
using System.Collections.Generic;
using Store.Domain.CustomerManagement;
using Store.Domain.ProductManagement;

namespace Store.Domain.OrderManagement
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
        public DateTime Date { get; set; }
    }
}

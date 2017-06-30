using System.Collections.Generic;
using Store.Domain.CustomerManagement;
using Store.Domain.ProductManagement;

namespace Store.Domain.CartManagement
{
    public class Cart
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

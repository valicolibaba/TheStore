using System.Collections.Generic;
using System.Runtime.Serialization;
using Store.Service.CustomerService.Data;
using Store.Service.ProductService.Data;

namespace Store.Service.OrderService.Data
{
    [DataContract]
    public class Cart
    {
        [DataMember]
        public virtual int Id { get; set; }
        [DataMember]
        public virtual Customer Customer { get; set; }
        [DataMember]
        public virtual ICollection<Product> Products { get; set; }
    }
}
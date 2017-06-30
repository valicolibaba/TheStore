using System.Collections.Generic;
using System.Runtime.Serialization;
using Store.Service.OrderService.Data;

namespace Store.Service.CustomerService.Data
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public virtual int Id { get; set; }
        [DataMember]
        public virtual string FirstName { get; set; }
        [DataMember]
        public virtual string LastName { get; set; }
        [DataMember]
        public virtual string Email { get; set; }
        [DataMember]
        public virtual string Address { get; set; }
        [DataMember]
        public virtual string Phone { get; set; }
        [DataMember]
        public virtual string Password { get; set; }
        [DataMember]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
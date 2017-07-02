using System.Runtime.Serialization;

namespace Store.Service.CustomerService.Data
{
    [DataContract]
    public class CustomerAccount
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
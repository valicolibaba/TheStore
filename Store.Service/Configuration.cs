using AutoMapper;
using Store.Common;
using Store.Domain.ProductManagement;

namespace Store.Service
{
    public class Configuration : StoreConfigurations
    {
        public override void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(ProductRepository), typeof(CustomerService.CustomerService));
            }
            );
        }
    }
}
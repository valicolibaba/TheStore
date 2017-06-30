using Autofac;
using AutoMapper;
using Store.Database;
using Store.Domain.CartManagement;
using Store.Domain.CustomerManagement;
using Store.Domain.OrderManagement;
using Store.Domain.ProductManagement;

namespace Store.Common
{
    public class StoreConfigurations
    {
        public ContainerBuilder AutofacBuilder;
        public IConfigurationProvider ConfigurationProvider;
        public virtual void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
                cfg.AddProfiles(typeof(ProductRepository))
            );
        }

        /// <summary>
        /// Setup Autofac for entire application.
        /// </summary>
        public virtual void ConfigureAutofac()
        {
            AutofacBuilder = new ContainerBuilder();
            AutofacBuilder.RegisterType<StoreContext>().InstancePerDependency();
            AutofacBuilder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
            AutofacBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerDependency();
            AutofacBuilder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerDependency();
            AutofacBuilder.RegisterType<CartRepository>().As<ICartRepository>().InstancePerDependency();
        }

        public IContainer BuildConfigurations()
        {
            return AutofacBuilder.Build();
        }
    }
}

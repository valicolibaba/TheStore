using System;
using Autofac;
using Autofac.Integration.Wcf;

namespace Store.Service
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var configuration = new Configuration();
            configuration.ConfigureAutoMapper();
            configuration.ConfigureAutofac();
            configuration.AutofacBuilder.RegisterType<CustomerService.CustomerService>();
            configuration.AutofacBuilder.RegisterType<ProductService.ProductService>();
            configuration.AutofacBuilder.RegisterType<OrderService.OrderService>();
            configuration.AutofacBuilder.RegisterType<Service>();
            var container = configuration.AutofacBuilder.Build(); 
            AutofacHostFactory.Container = container;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
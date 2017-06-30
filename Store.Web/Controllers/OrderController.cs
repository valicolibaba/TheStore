using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Store.Web.CustomerService;
using Store.Web.Models;
using Store.Web.OrderService;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderServiceClient orderServiceClient;
        private readonly CustomerServiceClient customerServiceClient;

        public OrderController(OrderServiceClient orderServiceClient, CustomerServiceClient customerServiceClient)
        {
            this.orderServiceClient = orderServiceClient;
            this.customerServiceClient = customerServiceClient;
        }

        // GET: Order
        public ActionResult Index()
        {

            var customer = customerServiceClient.GetCustomerByEmail(User.Identity.Name);
            var orders = orderServiceClient.GetOrdersForCustomer(customer.Id);
            var customerOrdersViewMdoels = orders.Where(x => x.Customer.Email == User.Identity.Name).Select(Mapper.Map<OrderViewModel>).ToList();
            var model = new OrderListViewModel
            {
                Orders = customerOrdersViewMdoels
            };

            return View(model);
        }
    }
}
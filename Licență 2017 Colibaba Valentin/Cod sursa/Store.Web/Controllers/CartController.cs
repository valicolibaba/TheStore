using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Store.Web.CustomerService;
using Store.Web.Models;
using Store.Web.OrderService;
using Store.Web.Security;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly OrderServiceClient orderServiceClient;
        private readonly CustomerServiceClient customerServiceClient;

        public CartController(OrderServiceClient orderServiceClient, CustomerServiceClient customerServiceClient)
        {
            this.orderServiceClient = orderServiceClient;
            this.customerServiceClient = customerServiceClient;
        }

        [HttpGet]
        [AuthorizeUsers]
        // GET: Cart
        public ActionResult Index()
        {
            var userEmail = User.Identity.Name;
            var userCart = orderServiceClient.GetUserCart(userEmail);
            var cartProductsViewModel = userCart.Products.Select(Mapper.Map<ProductViewModel>).ToList();
            var totalPrice = cartProductsViewModel.Sum(x => x.Price);
            var model = new CardViewModel
            {
                Products = cartProductsViewModel,
                TotalPrice = totalPrice
            };
            return View(model);
        }

        [HttpGet]
        [AuthorizeUsers]
        public ActionResult AddProduct(int productId)
        {
            orderServiceClient.AddProductToCart(productId, @User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }

        [HttpGet]
        [AuthorizeUsers]
        public ActionResult DeleteProductFromCart(int productId)
        {
            orderServiceClient.DeleteProductFromCart(productId, @User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }
   
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Store.Web.CustomerService;
using Store.Web.Models;
using Store.Web.OrderService;
using Store.Web.ProductService;
using Store.Web.Security;
using Order = Store.Web.OrderService.Order;
using Product = Store.Web.ProductService.Product;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServiceClient productServiceClient;
        private readonly CustomerServiceClient customerServiceClient;
        private readonly OrderServiceClient orderServiceClient;

        public ProductController(ProductServiceClient productServiceClient, CustomerServiceClient customerServiceClient, OrderServiceClient orderServiceClient)
        {
            this.productServiceClient = productServiceClient;
            this.customerServiceClient = customerServiceClient;
            this.orderServiceClient = orderServiceClient;
        }

        [HttpGet]
        public ActionResult Index(string categoryName)
        {
            var products = productServiceClient.GetProductByCategoryName(categoryName);
            var productsViewModels = products.Select(Mapper.Map<ProductViewModel>).ToList();
            var model = new ProductListViewModel
            {
                Products = productsViewModels
            };

            return View(model);
        }
        [HttpGet]
        [AuthorizeUsers]
        public ActionResult ProductsByCategoryName(string categoryName)
        {
            var products = productServiceClient.GetProductByCategoryName(categoryName);
            var productsViewModels = products.Select(Mapper.Map<ProductViewModel>).ToList();
            var model = new ProductListViewModel
            {
                Products = productsViewModels
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Search(string name)
        {
            var products = productServiceClient.SearchProductsByName(name);
            var productsViewModels = products.Select(Mapper.Map<ProductViewModel>).ToList() ;
            var model = new ProductListViewModel
            {
                Products = productsViewModels
            };

            return View("Index", model);
        }

        [HttpGet]
        [AuthorizeUsers]
        public ActionResult SearchByName(string name)
        {
            var products = productServiceClient.SearchProductsByName(name);
            var productsViewModels = products.Select(Mapper.Map<ProductViewModel>).ToList();
            var model = new ProductListViewModel
            {
                Products = productsViewModels
            };

            return View("Index", model);
        }

     

        [HttpGet]
        [AuthorizeUsers(RequireAdmin = true)]
        // GET: Product
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var product = productServiceClient.GetProductById(id.Value);
                if (product != null)
                {
                    var productViewMdoel = Mapper.Map<ProductViewModel>(product);
                    return View(productViewMdoel);
                }
            }
            return View(new ProductViewModel {Id = 0});
        }

       
        [HttpPost]
        [AuthorizeUsers(RequireAdmin = true)]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel.Id <= 0)
                {
                    //Create
                    var product = Mapper.Map<Product>(productViewModel);
                    var file = productViewModel.FileImage;
                    if (file != null)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/Images/Products"), fileName);
                            file.SaveAs(path);
                            var imageUrl = Url.Action("Index", "Home");
                            imageUrl += "Content/Images/Products/" + fileName;
                            productViewModel.ImageUrl = imageUrl;
                            product.ImageUrl = imageUrl;
                        }
                    }
                    else
                    {
                        var imageUrl = Url.Action("Index", "Home");
                        imageUrl += "Content/Images/Products/default.jpg";
                        product.ImageUrl = imageUrl;
                    }
                    var productCreatedId = productServiceClient.AddProduct(product);
                    var createdProduct = productServiceClient.GetProductById(productCreatedId);
                    var createdProductViewModel = Mapper.Map<ProductViewModel>(createdProduct);
                    return View(createdProductViewModel);
                }
                else
                {
                    //Update
                    var product = Mapper.Map<Product>(productViewModel);
                    var file = productViewModel.FileImage;
                    if (file != null)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/Images/Products"), fileName);
                            file.SaveAs(path);
                            var imageUrl = Url.Action("Index", "Home");
                            imageUrl += "/Content/Images/Products/" + fileName;
                            productViewModel.ImageUrl = imageUrl;
                            product.ImageUrl = imageUrl;
                        }
                    }
                    else
                    {
                        var imageUrl = Url.Action("Index", "Home");
                        imageUrl += "/Content/Images/Products/default.jpg";
                        product.ImageUrl = imageUrl;
                    }
                    var updatedProductId = productServiceClient.UpdateProduct(product);
                    var updatedProduct = productServiceClient.GetProductById(updatedProductId);
                    var updatedProductViewModel = Mapper.Map<ProductViewModel>(updatedProduct);
                    return View(updatedProductViewModel);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AuthorizeUsers]
        public ActionResult Purchase()
        {
            var customer = customerServiceClient.GetCustomerByEmail(User.Identity.Name);
            var orderedProducts = orderServiceClient.GetUserCart(User.Identity.Name).Products;
            var order = new Order
            {
                Customer = Mapper.Map<OrderService.Customer>(customer),
                Date = DateTime.Now,
                Products = orderedProducts,
                Id = 0
            };

            orderServiceClient.AddOrder(order);
            orderServiceClient.DeleteUserCart(User.Identity.Name);
            return RedirectToAction("Index", "Order");
        }
    }
}
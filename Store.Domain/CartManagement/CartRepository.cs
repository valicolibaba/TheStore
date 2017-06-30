using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using Store.Database;
using Store.Domain.CustomerManagement;

namespace Store.Domain.CartManagement
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreContext context;
        public CartRepository(StoreContext context)
        {
            this.context = context;
        }

        public int CreateCart(string email)
        {
            var cartDto = new Database.Models.Cart()
            {
                Customer = context.Customers.SingleOrDefault(x => x.Email == email),
                Id = 0,
                Products = null
            };

            context.Carts.Add(cartDto);
            context.SaveChanges();

            return cartDto.Id;
        }

        public Cart GetUserCart(string email)
        {
            var cartDto = context.Carts.SingleOrDefault(x => x.Customer.Email == email);
            return cartDto != null ? Mapper.Map<Cart>(cartDto) : null;
        }

        public int UpdateUserCart(Cart cart)
        {
            var cartDao = Mapper.Map<Database.Models.Cart>(cart);
            context.Carts.AddOrUpdate(cartDao);
            context.SaveChanges();
            return cartDao.Id;
        }

        public int AddProductToCart(int productId, string userEmail)
        {
            var cartDto = context.Carts.SingleOrDefault(x => x.Customer.Email == userEmail);
            var productDao = context.Products.SingleOrDefault(x => x.Id == productId);
            cartDto?.Products.Add(productDao);
            context.SaveChanges();
            return 1;
        }

        public int DeleteProductFromCart(int productId, string userEmail)
        {
            var cartDto = context.Carts.SingleOrDefault(x => x.Customer.Email == userEmail);
            var productDto = context.Products.SingleOrDefault(x => x.Id == productId);
            cartDto?.Products.Remove(productDto);
            context.SaveChanges();
            return 1;
        }

        public int DeleteUserCart(string userEmail)
        {
            var cartDto = context.Carts.SingleOrDefault(x => x.Customer.Email == userEmail);
            cartDto.Products.Clear();
            context.SaveChanges();
            return 1;
        }
    }
}

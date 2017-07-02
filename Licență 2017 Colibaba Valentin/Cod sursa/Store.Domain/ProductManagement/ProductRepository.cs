using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using Store.Database;
using Store.Database.Migrations;

namespace Store.Domain.ProductManagement
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public IList<Product> GetAllProducts()
        {
            return storeContext.Products.Select(Mapper.Map<Product>).ToList();
        }

        public int UpdateProduct(Product product)
        {
            var productDto = Mapper.Map<Database.Models.Product>(product);
            storeContext.Products.AddOrUpdate(productDto);
            storeContext.SaveChanges();
            return productDto.Id;
        }

        public Product GetProductById(int id)
        {
            var product = storeContext.Products.SingleOrDefault(x => x.Id == id);
            return Mapper.Map<Product>(product);
        }

        public IList<Product> GetProductsByName(string name)
        {
            var productsDto = storeContext.Products.Where(x => x.Name.Trim().ToUpper().Contains(name.Trim().ToUpper()));
            return productsDto.Select(Mapper.Map<Product>).ToList();
        }

        public IList<Product> GetProductsByCategoryName(string categoryName)
        {
            var productsDtos = storeContext.Products.Where(x => x.CategoryName.Trim().ToUpper().Equals(categoryName));
            return productsDtos.Select(Mapper.Map<Product>).ToList();
        }

        public int AddProduct(Product product)
        {
            var productDto = Mapper.Map<Database.Models.Product>(product);
            storeContext.Products.Add(productDto);
            storeContext.SaveChanges();
            return productDto.Id;
        }

        public IList<string> GetPrducttNameForGivenName(string name)
        {
            return
                storeContext.Products.Where(x => x.Name.Trim().ToUpper().Contains(name.Trim().ToUpper()))
                    .Select(y => y.Name)
                    .ToList();
        }

        public bool DeleteProduct(int productId)
        {
            var product = storeContext.Products.SingleOrDefault(x => x.Id == productId);
            storeContext.Products.Remove(product);
            storeContext.SaveChanges();
            return true;
        }
    }
}

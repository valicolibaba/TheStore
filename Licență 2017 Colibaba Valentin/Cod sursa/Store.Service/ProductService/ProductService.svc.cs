using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.Domain.ProductManagement;
using Product = Store.Service.ProductService.Data.Product;

namespace Store.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = productRepository.GetAllProducts().Select(Mapper.Map<Product>);
            return products;
        }

        public IEnumerable<Product> GetProductByCategoryName(string categoryName)
        {
            var products = productRepository.GetProductsByCategoryName(categoryName).Select(Mapper.Map<Data.Product>);
            return products;
        }

        public int AddProduct(Product product)
        {
            var domainProduct = Mapper.Map<Domain.ProductManagement.Product>(product);
            var createdProductId = productRepository.AddProduct(domainProduct);
            return createdProductId;
        }

        public int UpdateProduct(Product product)
        {
            var domainProduct = Mapper.Map<Domain.ProductManagement.Product>(product);
            var updatedProductId = productRepository.UpdateProduct(domainProduct);
            return updatedProductId;
        }

        public Product GetProductById(int id)
        {
            var domainProduct = productRepository.GetProductById(id);
            return Mapper.Map<Product>(domainProduct);
        }

 
        public IEnumerable<Product> SearchProductsByName(string name)
        {
            return productRepository.GetProductsByName(name).Select(Mapper.Map<Product>).ToList();
        }

        public IEnumerable<string> GetProductSugestions(string productName)
        {
            return productRepository.GetPrducttNameForGivenName(productName).ToList();
        }

        public bool DeleteProduct(int productId)
        {
           
            return productRepository.DeleteProduct(productId);
        }
    }
}


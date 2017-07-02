using System.Collections.Generic;

namespace Store.Domain.ProductManagement
{
    public interface IProductRepository
    {
        IList<Product> GetAllProducts();
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        Product GetProductById(int id);
        IList<Product> GetProductsByName(string name);
        IList<Product> GetProductsByCategoryName(string categoryName);
        IList<string> GetPrducttNameForGivenName(string name);
        bool DeleteProduct(int productId);
    }
}
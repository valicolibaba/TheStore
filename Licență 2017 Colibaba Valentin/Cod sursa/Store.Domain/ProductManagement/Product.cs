

namespace Store.Domain.ProductManagement
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
    }
}

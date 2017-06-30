using System;
using Store.Domain.CustomerManagement;

namespace Store.Domain.ProductReviewManagement
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Customer Author { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public DateTime Date { get; set; }
    }
}

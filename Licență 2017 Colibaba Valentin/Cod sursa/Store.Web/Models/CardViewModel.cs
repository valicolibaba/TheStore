using System.Collections.Generic;

namespace Store.Web.Models
{
    public class CardViewModel
    {
        public IList<ProductViewModel> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
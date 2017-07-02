using System;
using System.Collections.Generic;

namespace Store.Web.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public UserAccountViewModel Customer { get; set; }
        public IList<ProductViewModel> Products { get; set; }
        public DateTime Date { get; set; }
    }
}
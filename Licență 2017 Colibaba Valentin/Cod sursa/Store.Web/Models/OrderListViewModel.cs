using System.Collections.Generic;

namespace Store.Web.Models
{
    public class OrderListViewModel
    {
        public IList<OrderViewModel> Orders { get; set; }
    }
}
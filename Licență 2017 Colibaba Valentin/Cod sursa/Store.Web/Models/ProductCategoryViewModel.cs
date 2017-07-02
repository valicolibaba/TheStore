using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Store.Web.Models
{
    public class ProductCategoryViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(256, ErrorMessage = "Category name must be smaller than 256 characters.")]
        [Display(Name = "Numele categoriei")]
        public string Name { get; set; }

        public  string Description { get; set; }

        public  ICollection<ProductViewModel> Products { get; set; }
    }
}
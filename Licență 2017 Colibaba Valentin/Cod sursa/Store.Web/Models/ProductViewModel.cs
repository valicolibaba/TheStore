using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.UI.WebControls;

namespace Store.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Numele produsului nu este introdus!")]
        [MaxLength(256,ErrorMessage = "Numele produsului trebuie să fie mai mic de 256 caractere!")]
        [Display(Name = "Numele produsului")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Categoria produsului nu este introdusă!")]
        [MaxLength(256, ErrorMessage = "Categoria produsului trebuie să fie mai mică de 256 caractere!")]
        [Display(Name = "Numele Categorie")]
        public string CategoryName { get; set; }

        [Display(Name = "Ingrediente")]
        [MaxLength(5000, ErrorMessage = "Ingredients must be smaller than 5000 characters.")]
        public string Ingredients { get; set; }

        [Display(Name = "Preț")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Imaginea produsului")]
        public HttpPostedFileBase FileImage { get; set; }
    }
}

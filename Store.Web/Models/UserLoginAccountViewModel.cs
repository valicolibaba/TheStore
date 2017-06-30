using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models
{
    public class UserLoginAccountViewModel
    { 
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email-ul nu este  introdus!")]
        [EmailAddress(ErrorMessage = "Email-ul nu este valid!")]
        public string Email { get; set; }
        [Display(Name = "Parolă")]
        [Required(ErrorMessage = "Parola nu este introdusă!")]
        [MinLength(6,ErrorMessage = "Dimensiunea parolei trebuie să fie mai mare de 6 caractere!")]
        [MaxLength(30,ErrorMessage = "Dimensiunea parolei trebuie să fie mai mică de 30 caractere!")]
        public string Password { get; set; }
    }
}
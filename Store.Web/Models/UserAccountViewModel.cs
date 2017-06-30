using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models
{
    public class UserAccountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Prenume")]
        [MaxLength(256, ErrorMessage = "Dimensiunea prenumelui trebuie să fie mai mica de 256 caractere!")]
        [Required(ErrorMessage = "Prenumele nu este introdus!")]
        public string FirstName { get; set; }

        [Display(Name = "Nume")]
        [MaxLength(256, ErrorMessage = "Dimensiunea numelui trebuie sa fie mai mica de 256 caractere!")]
        [Required(ErrorMessage = "Numele nu este introdus!")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [MaxLength(256, ErrorMessage = "Dimensiunea email-ului trebuie să fie mai mică de 256 caractere!")]
        [Required(ErrorMessage = "Email-ul nu este introdus!")]
        [EmailAddress(ErrorMessage = "Email-ul nu este valid!")]
        public string Email { get; set; }

        [Display(Name = "Adresă")]
        [MaxLength(256, ErrorMessage = "Dimensiunea adresei trebuie să fie mai mică de 256 caractere!")]
        [Required(ErrorMessage = "Adresa nu este introdusă!")]
        public string Address { get; set; }

        [Display(Name = "Număr de telefon")]
        [Phone(ErrorMessage = "Numprul de telefon nu este valid")]
        [MaxLength(10, ErrorMessage = "Dimensiunea numărului de telefon trebuie să fie mai mică de 10 caractere!")]
        public string Phone { get; set; }

        [Display(Name = "Parolă")]
        [Required(ErrorMessage = "Parola nu este introdusă!")]
        [MinLength(6, ErrorMessage = "Dimensiunea parolei trebuie să fie mai mare de 6 caractere!")]
        [MaxLength(30, ErrorMessage = "Dimensiunea parolei trebuie să fie mai mică de 30 caractere!")]
        public string Password { get; set; }
    }
}
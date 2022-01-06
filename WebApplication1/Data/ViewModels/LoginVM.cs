using System.ComponentModel.DataAnnotations;

namespace Filmy.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Emailova adresa je vyzadovana")]
        [EmailAddress]
        [Display(Name = "Emailova adresa :")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo :")]
        public string Password { get; set; }
    }
}

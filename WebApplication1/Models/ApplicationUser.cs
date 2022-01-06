using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Filmy.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Cele jmeno")]
        public string FullName { get; set; }
    }
}

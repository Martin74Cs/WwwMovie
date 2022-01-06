using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Filmy.Data.Base;

namespace Filmy.Models
{
    public class Actor : IEntityBase

    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profilovy Obrazek")]
        [Required(ErrorMessage = "Profilovy Obrazek musí být vyplnìn")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Cele jméno")]
        [Required(ErrorMessage = "Cele jméno musí být vyplnìno")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Celé jmeno musí mít 3-50 znakù")]
        public string FullName { get; set; }

        [Display(Name = "Zivotopis")]
        [Required(ErrorMessage = "Zivotopis musí být vyplnìn")]
        public string Bio { get; set; }

        //realationship
        public List<Actor_Movie> Actor_Movie { get; set; }

    }
}

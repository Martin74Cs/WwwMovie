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
        [Required(ErrorMessage = "Profilovy Obrazek mus� b�t vypln�n")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Cele jm�no")]
        [Required(ErrorMessage = "Cele jm�no mus� b�t vypln�no")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Cel� jmeno mus� m�t 3-50 znak�")]
        public string FullName { get; set; }

        [Display(Name = "Zivotopis")]
        [Required(ErrorMessage = "Zivotopis mus� b�t vypln�n")]
        public string Bio { get; set; }

        //realationship
        public List<Actor_Movie> Actor_Movie { get; set; }

    }
}

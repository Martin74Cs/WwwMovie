using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Filmy.Data.Base;

namespace Filmy.Models
{
    public class Producer : IEntityBase

    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profilovy Obrazek")]
        public string ProfilePicturesUrl { get; set; }

        [Display(Name = "Cele Jmeno")]
        public string FullName { get; set; }
        public string Bio { get; set; }

        [Display(Name = "Zivotopis")]
        //realationship
        public List<Movie> Movie { get; set; }

    }
}

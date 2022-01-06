using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Filmy.Data.Base;

namespace Filmy.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Obrazek Kina")]
        public string Logo { get; set; }

        [Display(Name = "Jmeno Kina")]
        public string Name { get; set; }

        [Display(Name = "Popis Kina")]
        public string Description { get; set; }
        //realationship
        public List<Movie> Movie { get; set; }

 
    }
}

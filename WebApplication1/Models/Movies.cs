using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filmy.Data.Base;

namespace Filmy.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //realationship
        public List<Actor_Movie> Actor_Movie { get; set; }

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

    }


    //[Key]
    //    public int Id { get; set; }

    //    public string Logo { get; set; }
    //    public double Name { get; set; }
    //    public string Description { get; set; }
    //    public MovieCategory MovieCategory { get; set; }
    //    //realationship
    //    public List<Actor_Movie> Actor_Movie { get; set; }

    //    //Cinema
    //    public Cinema Cinema { get; set; }
    //}
}

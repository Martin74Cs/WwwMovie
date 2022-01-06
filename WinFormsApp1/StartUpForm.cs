using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filmy.Data.Services;
using Filmy.Models;
#nullable disable
using Microsoft.EntityFrameworkCore.Metadata;

namespace WinFormsApp1
{
    public partial class StartUpForm : DbContext
    {
        public StartUpForm()  { }

        public StartUpForm(DbContextOptions<StartUpForm> options) 
            : base(options) {  }

        public DbSet<Actor> Actor { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public  DbSet<Producer> Producer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("FilmKnihovna:PraceSqlSever"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId,
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movie)
                .HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movie)
                .HasForeignKey(m => m.ActorId);

            //var Actor_Movies = modelBuilder.Entity<Actor_Movie>();
            //Actor_Movies.ToTable("Actor-s"); //zmena nazvu tabulky
            //Actor_Movies.Property(b => b.Movie).IsRequired(); //zmena není dovoleno NUll;
            //Actor_Movies.HasKey(b => b.Movie); //nastaveni  primarni klic
            //Actor_Movies.HasKey(b => new { b.Movie, b.Actor }); //složený primární klíč
            //Actor_Movies.Ignore(b => b.Movie); //vynechá parametr v databazi
            //Actor_Movies.HasOne(b => b.Movie).WithMany(m => m.Actor_Movie).HasForeignKey(m => m.MovieId);
            ////jeden Movie z Actor_Movies odpovida mnoha MovieId z Actor_Movies
            //Actor_Movies.HasOne(b => b.Actor).WithMany(m => m.Actor_Movie).HasForeignKey(m => m.ActorId);
            ////jeden Actor z Actor_Movies odpovida mnoha ActorId z Actor_Movies

            //Actor_Movies.Property(b => b.Actor).HasColumnName("Herec"); //zmena sloupce Actor na Herec
            //Actor_Movies.Property(b => b.Actor).HasColumnType("varchar(20)"); //změna datového typu
            //Actor_Movies.Property(b => b.Actor).HasMaxLength(30); //změna delky DATOVÉHO TYPU

            //Actor_Movies.Property(b => b.Actor).HasColumnType("decimal(5,2)"); //změna datového typu

            //modelBuilder.Entity<Actor>().Property(b => b.FullName);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}






using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Filmy.Data.Static;

namespace Filmy.Models
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Cinema-kina
                if(!context.Cinema.Any())
                {
                    context.Cinema.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Kino1",
                            Description = "Poppis Kina cislo.1"
                        },

                        new Cinema()
                        {
                            Name = "Kino2",
                            Description = "Poppis Kina cislo.2"
                        }
                    });
                    context.SaveChanges();
                }
                //Actor-herci
                if(!context.Actor.Any())
                {
                    context.Actor.AddRange(new List<Actor>() 
                    { 
                        new Actor() 
                        { FullName="Jmeno1",Bio="Biologicka data1",},
                        new Actor()
                        { FullName="Jmeno2",Bio="Biologicka data2",},
                        new Actor()
                        { FullName="Jmeno3",Bio="Biologicka data3",}
                    });
                    context.SaveChanges();
                }
                //Producers-herci
                if(!context.Producer.Any())
                {
                    context.Producer.AddRange(new List<Producer>()
                    {
                        new Producer()
                        { FullName="Jmeno1",Bio="Biologicka data1",},
                        new Producer()
                        { FullName="Jmeno2",Bio="Biologicka data2",},
                        new Producer()
                        { FullName="Jmeno3",Bio="Biologicka data3",}
                    });
                    context.SaveChanges();
                }
                //Movie-filmy
                if(!context.Movie.Any())
                {
                    context.Movie.AddRange(new List<Movie>()
                    {
                        new Movie()
                        { Name="Jmeno filmu1",Description ="Popis filmu1",Price=29.90,
                            StartDate=DateTime.Now.AddDays(-10),EndDate=DateTime.Now.AddDays(-1),
                        CinemaId =1, ProducerId=2,MovieCategory=MovieCategory.Carton},
                        new Movie()
                        { Name="Jmeno filmu2",Description ="Popis filmu2",Price=39.90,
                            StartDate=DateTime.Now.AddDays(-10),EndDate=DateTime.Now.AddDays(-1),
                        CinemaId =1, ProducerId=2,MovieCategory=MovieCategory.Drama},
                        new Movie()
                        { Name="Jmeno filmu3",Description ="Popis filmu3",Price=49.90,
                            StartDate=DateTime.Now.AddDays(-10),EndDate=DateTime.Now.AddDays(-1),
                        CinemaId =1, ProducerId=2,MovieCategory=MovieCategory.Comedy},
                    });
                    context.SaveChanges();
                }
                //Actor&Movie herci ve filmech
                if(!context.Actor_Movie.Any())
                {
                    context.Actor_Movie.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        { 
                            ActorId=1,
                            MovieId=1,
                        },
                         new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId=1,
                        },
                         new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId=2,
                        },
                         new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId=2,
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }

    }
}

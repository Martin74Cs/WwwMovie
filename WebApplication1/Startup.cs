using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmy.Models;
using Microsoft.EntityFrameworkCore;
using Filmy.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Filmy.Data.Cart;

namespace Filmy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration=configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("FilmKnihovna:DefaultSqlSever")));
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("FilmKnihovna:PraceSqlSever")));

            //sevices konfigurace
            services.AddScoped<IActorServices, ActorServices>();
            services.AddScoped<IProducerSevices, ProducerService>();
            services.AddScoped<ICinemaSevices, CinemaSevices>();
            services.AddScoped<IMovieServices, MovieSevices>();
            services.AddScoped<IOrdersService, OrdersService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            //Authentication and authorization
            services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 2;
                option.Password.RequiredUniqueChars = 0;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = false;
                
            }).AddEntityFrameworkStores<AppDbContext>();

            //nebo
            //services.Configure<IdentityOptions>(option =>
            //{
            //    option.Password.RequiredLength = 2;
            //    option.Password.RequiredUniqueChars = 0;
            //    option.Password.RequireNonAlphanumeric = false;
            //});

            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            //Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}");
            });

            //Seed database
            //AppDbInitializer.Seed(app);
            //AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
        }
    }
  
}

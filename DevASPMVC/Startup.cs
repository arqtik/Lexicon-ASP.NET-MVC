using DevASPMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DevASPMVC
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            });

            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "doctor",
                    pattern: "FeverCheck",
                    defaults: new { controller = "Doctor", action = "FeverCheck" });
                endpoints.MapControllerRoute(
                    name: "guessingGame",
                    pattern: "GuessingGame",
                    defaults: new { controller = "GuessingGame", action = "Game" });
                endpoints.MapControllerRoute(
                    name: "people",
                    pattern: "people/{query?}",
                    defaults: new {controller = "People", action = "Index"});
                endpoints.MapControllerRoute(
                    name: "ajax",
                    pattern: "ajax",
                    defaults: new {controller = "Ajax", action = "Index"});
                endpoints.MapControllerRoute(
                    name: "city",
                    pattern: "city",
                    defaults: new {controller = "city", action = "index"});
                endpoints.MapControllerRoute(
                    name: "country",
                    pattern: "country",
                    defaults: new { controller = "country", action = "index" });
                endpoints.MapRazorPages();
            });
        }
    }
}

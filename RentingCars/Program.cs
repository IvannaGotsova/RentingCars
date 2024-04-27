using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentingCars.Common;
using RentingCars.Data.Data;
using RentingCars.Data.Data.Entities;
using RentingCars.Core.Services.Brokers;
using RentingCars.Core.Services.Cars;
using RentingCars.Core.Services.Statistics;
using RentingCars.Core.Services.ApplicationUsers;
using RentingCars.Controllers;
using Microsoft.AspNetCore.Builder;
using RentingCars.Core.Services.Rents;

namespace RentingCars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            IServiceCollection serviceCollection = builder.Services.AddDbContext<RentingCarsDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>
            (options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
            
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<RentingCarsDbContext>();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IBrokerService, BrokerService>();
            builder.Services.AddScoped<IStatisticsService, StatisticsService>();
            builder.Services.AddScoped<IRentService, RentService>();
            builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();

            builder.Services.AddAutoMapper(
                typeof(ICarService).Assembly,
                typeof(HomeController).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Areas",
                    pattern: "{area:exists}/{controller=Home}/{action}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Car Details",
                    pattern: "/Cars/Details/{id}/{information}",
                    defaults: new { Controller = "Cars", Action = "Details"});                       

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            app.MapRazorPages();

            app.SeedAdmin();

            app.Run();
        }      
    }
}

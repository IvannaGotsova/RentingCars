using Microsoft.AspNetCore.Identity;
using RentingCars.Data.Entities;

namespace RentingCars.Common
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(
            this IApplicationBuilder applicationBuilder)
        {
            using var scopedServices =
                applicationBuilder
                .ApplicationServices.CreateScope();

            var services = 
                scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync("Administrator"))
                {
                    return;
                }

                var role = new IdentityRole { Name = "Administrator" };

                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByNameAsync("admin@mail.com");

                await userManager.AddToRoleAsync(admin, role.Name);
            })
                .GetAwaiter()
                .GetResult();

            return applicationBuilder;

        }

    }
}

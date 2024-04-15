using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentingCars.Data.Entities;

namespace RentingCars.Data
{
    public class RentingCarsDbContext : IdentityDbContext<ApplicationUser>
    {
        public RentingCarsDbContext(DbContextOptions<RentingCarsDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<Broker> Brokers {  get; init; }
        public DbSet<Car> Cars { get; init; }
        public DbSet<Type> Types { get; init; }

        private IdentityUser BrokerUser { get; set; }
        private IdentityUser DemoUser { get; set; }
        private Type Family { get; set; }
        private Type Standard { get; set; }
        private Type Luxury { get; set; }
        private Car FamilyCar { get; set; }
        private Car StandardCar { get; set; }
        private Car LuxuryCar { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Car>()
                .HasOne(c => c.Type)
                .WithMany()
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Car>()
                .HasOne(c => c.Broker)
                .WithMany()
                .HasForeignKey(c => c.BrokerId)
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(builder);
        }
    }
}

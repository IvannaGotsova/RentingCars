using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentingCars.Data.Entities;
using RentingCars;

namespace RentingCars.Data
{
    public class RentingCarsDbContext : IdentityDbContext<ApplicationUser>
    {
        public RentingCarsDbContext(DbContextOptions<RentingCarsDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Broker>? Brokers { get; init; } = null!;
        public DbSet<Car>? Cars { get; init; } = null!;
        public DbSet<Entities.Type>? Types { get; init; } = null!;

        private ApplicationUser AdminUser { get; set; } = null!;
        private ApplicationUser BrokerUser { get; set; } = null!;
        private ApplicationUser DemoUser { get; set; } = null!;
        private Entities.Type Family { get; set; } = null!;
        private Entities.Type Standard { get; set; } = null!;
        private Entities.Type Luxury { get; set; } = null!;
        private Car FamilyCar { get; set; } = null!;
        private Car StandardCar { get; set; } = null!;
        private Car LuxuryCar { get; set; } = null!;
        private Broker AdminBroker { get; set; } = null!;
        private Broker Broker { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Car>()
                .HasOne(c => c.Type)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Car>()
                .HasOne(c => c.Broker)
                .WithMany()
                .HasForeignKey(c => c.BrokerId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder
                .Entity<ApplicationUser>()
                .HasData(this.BrokerUser, this.DemoUser, this.AdminUser);

            SeedBrokers();
            builder
                .Entity<Broker>()
                .HasData(this.Broker, this.AdminBroker);

            SeedTypes();
            builder
                .Entity<Entities.Type>()
                .HasData(this.Family, this.Standard, this.Luxury);

            SeedCars();
            builder
                .Entity<Car>()
                .HasData(this.FamilyCar, this.StandardCar, this.LuxuryCar);

            builder
                .Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder
               .Entity<ApplicationUser>()
               .Property(u => u.FirstName)
               .HasMaxLength(60)
               .IsRequired();

            builder
               .Entity<ApplicationUser>()
               .Property(u => u.LastName)
               .HasMaxLength(60)
               .IsRequired();

            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            this.BrokerUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "brokeruser@example.com",
                NormalizedUserName = "brokeruser@example.com",
                Email = "brokeruser@example.com",
                NormalizedEmail = "brokeruser@example.com",
                FirstName = "Ivan",
                LastName = "Ivanov"

            };

            this.BrokerUser.PasswordHash =
                 hasher.HashPassword(this.BrokerUser, "brokeruser123");

            this.DemoUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "demouser@example.com",
                NormalizedUserName = "demouser@example.com",
                Email = "demouser@example.com",
                NormalizedEmail = "demouser@example.com",
                FirstName = "Petar",
                LastName = "Petrov"
            };

            this.DemoUser.PasswordHash =
            hasher.HashPassword(this.DemoUser, "demouser123");

            this.AdminUser = new ApplicationUser()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                FirstName = "Admin",
                LastName = "Admin"
            };

            this.AdminUser.PasswordHash =
                 hasher.HashPassword(this.BrokerUser, "admin123");
        }

        private void SeedBrokers()
        {
            this.Broker = new Broker()
            {
                Id = 1,
                BrokerPhoneNumber = "+0000000000",
                UserId = this.BrokerUser.Id
            };

            this.AdminBroker = new Broker()
            {
                Id = 2,
                BrokerPhoneNumber = "+0000000000",
                UserId = this.AdminUser.Id
            };
        }

        private void SeedTypes()
        {
            this.Family = new Entities.Type()
            {
                Id = 1,
                TypeName = "Family"
            };

            this.Standard = new Entities.Type()
            {
                Id = 2,
                TypeName = "Standard"
            };

            this.Luxury = new Entities.Type()
            {
                Id = 3,
                TypeName = "Luxury"
            };

        }

        private void SeedCars()
        {
            this.FamilyCar = new Car()
            {
                Id = 1,
                CarImageUrl = "/Photos/Picture.jpg",
                CarBrand = "FamilyBrand",
                CarModel = "FamilyModel",
                CarDescription = "Family Car Description ...",
                CarAdditionalInformation = "Family Car AdditionaInformation ...",
                CarPricePerDay = 300,
                TypeId = this.Family.Id,
                BrokerId = this.Broker.Id,
                RenterId = this.DemoUser.Id
            };

            this.StandardCar = new Car()
            {
                Id = 2,
                CarImageUrl = "/Photos/Picture.jpg",
                CarBrand = "StandardBrand",
                CarModel = "StandardModel",
                CarDescription = "Standard Car Description ...",
                CarAdditionalInformation = "Standard Car AdditionaInformation ...",
                CarPricePerDay = 200,
                TypeId = this.Standard.Id,
                BrokerId = this.Broker.Id
            };

            this.LuxuryCar = new Car()
            {
                Id = 3,
                CarImageUrl = "/Photos/Picture.jpg",
                CarBrand = "LuxuryBrand",
                CarModel = "LuxuryModel",
                CarDescription = "Luxury Car Description ...",
                CarAdditionalInformation = "Luxury Car AdditionaInformation ...",
                CarPricePerDay = 500,
                TypeId = this.Luxury.Id,
                BrokerId = this.Broker.Id
            };
        }
    }
}

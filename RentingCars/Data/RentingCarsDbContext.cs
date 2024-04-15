﻿using Microsoft.AspNetCore.Identity;
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

        public DbSet<Broker>? Brokers { get; init; } = null!;
        public DbSet<Car>? Cars { get; init; } = null!;
        public DbSet<Entities.Type>? Types { get; init; } = null!;

        private IdentityUser BrokerUser { get; set; } = null!;
        private IdentityUser DemoUser { get; set; } = null!;
        private Entities.Type Family { get; set; } = null!;
        private Entities.Type Standard { get; set; } = null!;
        private Entities.Type Luxury { get; set; } = null!;
        private Car FamilyCar { get; set; } = null!;
        private Car StandardCar { get; set; } = null!;
        private Car LuxuryCar { get; set; } = null!;
        private Broker Broker { get; set; } = null!;
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

            SeedUsers();
            builder
                .Entity<IdentityUser>()
                .HasData(this.BrokerUser, this.DemoUser);

            SeedBrokers();
            builder
                .Entity<Broker>()
                .HasData(this.Broker);

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
            var hasher = new PasswordHasher<IdentityUser>();

            this.BrokerUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "brokeruser@example.com",
                NormalizedUserName = "brokeruser@example.com",
                Email = "brokeruser@example.com",
                NormalizedEmail = "brokeruser@example.com",
            };

            this.BrokerUser.PasswordHash =
                 hasher.HashPassword(this.BrokerUser, "brokeruser123");

            this.DemoUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "demouser@example.com",
                NormalizedUserName = "demouser@example.com",
                Email = "demouser@example.com",
                NormalizedEmail = "demouser@example.com",
            };

            this.DemoUser.PasswordHash =
            hasher.HashPassword(this.DemoUser, "demouser123");
        }

        private void SeedBrokers()
        {
            this.Broker = new Broker()
            {
                Id = 1,
                BrokerPhoneNumber = "+0000000000",
                UserId = this.BrokerUser.Id
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
                Id = 1,
                TypeName = "Standard"
            };

            this.Luxury = new Entities.Type()
            {
                Id = 1,
                TypeName = "Luxury"
            };

        }

        private void SeedCars()
        {
            this.FamilyCar = new Car()
            {
                Id = 1,

            };
        }
    }
}

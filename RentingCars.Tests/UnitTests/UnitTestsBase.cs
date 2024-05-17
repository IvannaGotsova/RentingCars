using Microsoft.EntityFrameworkCore.Storage;
using RentingCars.Data.Data;
using RentingCars.Data.Data.Entities;
using RentingCars.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected RentingCarsDbContext RentingCarsDbContextData;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            this.RentingCarsDbContextData = DatabaseMock.Instance;
            this.SeedDataBase();
        }

        public ApplicationUser Renter { get; private set; }
        public Broker Broker { get; private set; }
        public Car Car { get; private set; }

        private void SeedDataBase() 
        {
            this.Renter = new ApplicationUser()
            {
                Id = "RenterApplicationUserId",
                Email = "renter@renter.com",
                FirstName = "Renter",
                LastName = "Renter"
            };
            this.RentingCarsDbContextData.ApplicationUsers.Add(this.Renter);

            this.Broker = new Broker()
            {
                BrokerPhoneNumber = "0000000000",
                User = new ApplicationUser()
                {
                    Id = "BrokerApplicationUserId",
                    Email = "broker@broker.com",
                    FirstName = "Broker",
                    LastName = "Broker"
                },
               
            };
            this.RentingCarsDbContextData.Brokers.Add(this.Broker);

            this.Car = new Car()
            {
                CarImageUrl = "/Photos/Picture.jpg",
                CarBrand = "TestBrand",
                CarModel = "TestModel",
                CarDescription = "Test Car Description ...",
                CarAdditionalInformation = "Test Car AdditionaInformation ...",
                CarPricePerDay = 1000,
                Type = new Data.Data.Entities.Type() { TypeName = "Test Type" },
                Broker = this.Broker,
                Renter = this.Renter
            };
            this.RentingCarsDbContextData.Add(this.Car);

            var notRentedCar = new Car()
            {
                CarImageUrl = "/Photos/Picture.jpg",
                CarBrand = "NotRentedBrand",
                CarModel = "NotRentedModel",
                CarDescription = "Not Rented Car Description ...",
                CarAdditionalInformation = "Not Rented Car AdditionaInformation ...",
                CarPricePerDay = 100,
                Type = new Data.Data.Entities.Type() { TypeName = "Not Rented Type" },
                Broker = this.Broker,
                Renter = this.Renter
            };
            this.RentingCarsDbContextData.Add(notRentedCar);
            this.RentingCarsDbContextData.SaveChanges();

        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            this.RentingCarsDbContextData.Dispose();
        }
    }
}

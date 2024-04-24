using AutoMapper;
using RentingCars.Core.Services.Models.Cars;
using RentingCars.Data.Data.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Core.Services.Infrastructure
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile() 
        {
            this.CreateMap<CarDetailsServiceModel, CarRequestModel>();
            this.CreateMap<CarDetailsServiceModel, CarDetailsRequestModel>();
        }
    }
}

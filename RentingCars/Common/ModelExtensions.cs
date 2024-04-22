using RentingCars.Services.Models.Cars;
using System.Text.RegularExpressions;

namespace RentingCars.Common
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICarModel carModel)
        {
            return carModel.CarBrand.Replace(" ", "-") + "-" + GetDescription(carModel.CarDescription) + GetAdditionalInformation(carModel.CarAdditionalInformation);
        }

        public static string GetDescription(string carDescription)
        {
            carDescription = string.Join("-", carDescription.Split(" ").Take(3));

            return carDescription;
        }

        public static string GetAdditionalInformation(string carAdditionalInformation)
        {
            carAdditionalInformation = string.Join("-", carAdditionalInformation.Split(" ").Take(3));

            return carAdditionalInformation;
        }
    }
}

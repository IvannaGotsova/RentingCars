﻿namespace RentingCars.Data
{
    public class DataConstants
    {
        public class BrokerConstants
        {
            public const int BrokerPhoneNumberMinLength = 3;
            public const int BrokerPhoneNumberMaxLength = 20;
        }

        public class CarConstants
        {
            public const int CarBrandMinLength = 1;
            public const int CarBrandMaxLength = 100;
            public const int CarModelMinLength = 1;
            public const int CarModelMaxLength = 100;
            public const int CarDescriptionMinLength = 3;
            public const int CarDescriptionMaxLength = 1000;
            public const int CarAdditionalInformationMinLength = 3;
            public const int CarAdditionalInformationMaxLength = 5000;
        }

        public class TypeConstants
        {
            public const int TypeNameMinLength = 1;
            public const int TypeNameMaxLength = 100;
        }

    }
}

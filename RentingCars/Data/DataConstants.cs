namespace RentingCars.Data
{
    public class DataConstants
    {
        public class ApplicationUserConstants
        {
            public const int AppUserUserNameMinLength = 1;
            public const int AppUserUserNameMaxLength = 100;
            public const int AppUserFirstNameMinLength = 1;
            public const int AppUserFirstNameMaxLength = 100;
            public const int AppUserLastNameMinLength = 1;
            public const int AppUserLastNameMaxLength = 100;
            public const int AppUserEmailMinLength = 1;
            public const int AppUserEmailMaxLength = 100;
            public const int AppUserPasswordMinLength = 1;
            public const int AppUserPasswordMaxLength = 100;
        }
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

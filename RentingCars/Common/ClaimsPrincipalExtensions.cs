using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace RentingCars.Common
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}

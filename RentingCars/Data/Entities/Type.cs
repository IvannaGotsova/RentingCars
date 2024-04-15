using RentingCars.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.DataConstants.TypeConstants;


namespace RentingCars.Data.Entities
{
    public class Type
    {
        public int Id { get; init; }
        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string TypeName { get; set; }
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}

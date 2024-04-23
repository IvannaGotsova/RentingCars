using RentingCars.Data.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static RentingCars.Data.Data.DataConstants.TypeConstants;


namespace RentingCars.Data.Data.Entities
{
    public class Type
    {
        public int Id { get; init; }
        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string? TypeName { get; set; }
        public IEnumerable<Car> Cars { get; init; } = new List<Car>();
    }
}

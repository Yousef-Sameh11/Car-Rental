using CarRentalSystem.Models.Cars;

namespace CarRentalSystem.Models.BrandModel
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Car> cars { get; set; }
    }
}

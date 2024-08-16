using CarRentalSystem.Dtos.CarDtos;

namespace CarRentalSystem.Dtos.BrandDtos
{
    public class BrandCarsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CarDto> Cars { get; set; }
    }
}

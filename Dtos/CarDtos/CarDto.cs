using CarRentalSystem.Dtos.CategoryDtos;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarRentalSystem.Dtos.CarDtos
{
    public class CarDto
    {
        public int Id { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public ICollection<CategoryDto> Categories { get; set; }
    }
}

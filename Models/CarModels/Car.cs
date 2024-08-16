using CarRentalSystem.Models.BrandModel;
using CarRentalSystem.Models.CarCategoryModel;
using CarRentalSystem.Models.RentalModels;
using System.ComponentModel;

namespace CarRentalSystem.Models.Cars
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Model {  get; set; }

        public decimal Price { get; set; }

        public string Picture {  get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int Availability {  get; set; }
        public ICollection<CarCategories> CarCategories { get; set; }
        public ICollection<Rental> Rentals { get; set; }



    }
}

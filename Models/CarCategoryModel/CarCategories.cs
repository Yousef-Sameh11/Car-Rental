using CarRentalSystem.Models.Cars;
using CarRentalSystem.Models.CategoryModels;



namespace CarRentalSystem.Models.CarCategoryModel
{
    public class CarCategories
    {
        public int CarId { get; set; }

        public Car Car { get; set; }

        public int CategoryId {  get; set; }

        public Category Category { get; set; }



    }
}

using CarRentalSystem.Models.CarCategoryModel;

namespace CarRentalSystem.Models.CategoryModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CarCategories> CarCategories { get; set; }
    }
}

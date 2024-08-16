using CarRentalSystem.Dtos.CategoryDtos;

namespace CarRentalSystem.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategoryById(int categoryid);
        Task AddCategory(CategoryDto categoryDto);
        Task DeleteCategory(int categoryid);
        Task<ICollection<CategoryDto>> GetCategoriesOfACar(int carid);




    }
}

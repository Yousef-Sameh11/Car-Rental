using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Dtos.CategoryDtos;
using CarRentalSystem.IServices;
using CarRentalSystem.Models.CategoryModels;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CategoryService(Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public Task DeleteCategory(int categoryid)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoriesdto = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesdto;

        }

        public async Task<CategoryDto> GetCategoryById(int categoryid)
        {
            var category = await _context.Categories.FirstOrDefaultAsync();
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesOfACar(int carid)
        {
            var categories = await _context.CarCategories.Where(c => c.CarId == carid).Select(d => new CategoryDto
            {
                Id = d.CategoryId,
                Name = d.Category.Name,
 

            }).ToListAsync();
            return categories;

        }
    }
}

using CarRentalSystem.Dtos.CategoryDtos;
using CarRentalSystem.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }


        [HttpGet("GetAllCategoriesOfACar/{carId}")]
        public async Task<IActionResult>GetAllCategoriesOfACar(int carId)
        {
            var categories =await _categoryService.GetCategoriesOfACar(carId);
            return Ok(categories);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryDto category)
        {
            await _categoryService.AddCategory(category);
            return Ok($"Succesfuly created {category.Name}");
        }

    }
}

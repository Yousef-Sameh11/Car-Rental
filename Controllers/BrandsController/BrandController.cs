using CarRentalSystem.Dtos.BrandDtos;
using CarRentalSystem.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers.BrandsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("GetAllBrandsAsync")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("GetAllBrandCars")]
        public async Task<IActionResult> GetAllBrandCars()
        {
            var brands = await _brandService.GetAllBrandCarsAsync();
            return Ok(brands);
        }

        [HttpGet("GetBrandCars/{brandId}")]
        public async Task<IActionResult> GetBrandCars(int brandId)
        {
            var brands = await _brandService.GetBrandCarsAsync( brandId);
            return Ok(brands);
        }

        [HttpGet("GetBrandById/{brandId}")]
        public async Task<IActionResult> GetBrandById(int brandId)
        {
            var brand = await _brandService.GetBrandById(brandId);
            return Ok(brand);
        }



        [HttpPost("AddBrand")]
        public async Task<IActionResult> AddBrand(BrandRequestDto brandRequestDto)
        {
            await _brandService.AddBrand(brandRequestDto);
            return Ok($"Succesfully Created Brand : {brandRequestDto.Name}");
        }
    }
}

using CarRentalSystem.Dtos.CarDtos;
using CarRentalSystem.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers.CarsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCars();
            return Ok(cars);
        }


        [HttpGet("GetCarById/{carId}")]
        public async Task<IActionResult> GetCarById(int carId)
        {
            var car = await _carService.GetCarById(carId);
            return Ok(car);
        }

        [HttpPost("AddCar")]
        public async Task<IActionResult> AddCar(CarRequestDto carRequest)
        {
            await _carService.AddCar(carRequest);
            return Ok($"Succesfuly Created Car {carRequest.CarName}");
        }


        [HttpDelete("DeleteCar/{carId}")]

        public async Task<IActionResult> DeleteCar(int carId)
        {
            await _carService.DeleteCar(carId);
            return Ok("Succesfuly Deleted Car");
        }

        [HttpGet("GetAllCarsByBrandId/{brandId}")]
        public async Task<IActionResult> GetAllCarsByBrandId(int brandId)
        {
            var cars = await _carService.GetAllCarsByBrandId(brandId);
            return Ok(cars);
        }


        [HttpGet("GetAllCarsByBrandName/{brandName}")]
        public async Task<IActionResult> GetAllCarsByBrandName(string brandName)
        {
            var cars = await _carService.GetAllCarsByBrandName(brandName);
            return Ok(cars);
        }


        [HttpGet("GetAllCarsByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetAllCarsByCategoryId(int categoryId)
        {
            var cars = await _carService.GetAllCarsByCategoryId(categoryId);
            return Ok(cars);
        }
    }
}

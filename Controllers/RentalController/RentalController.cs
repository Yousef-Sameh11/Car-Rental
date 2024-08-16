using CarRentalSystem.Dtos.RentalDtos;
using CarRentalSystem.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers.RentalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }


        [HttpGet("GetAllRentals")]
        public async Task<IActionResult> GetAllRentals()
        {
            var rentals = await _rentalService.GetAllRentals();
            return Ok(rentals);
        }

        [HttpGet("GetAllUserRentals/{userId}")]
        public async Task<IActionResult> GetAllUserRentals(int userId)
        {
            var rentals = await _rentalService.GetAllUserRentals(userId);
            return Ok(rentals);
        }

        [HttpPost("RentCar")]
        public async Task<IActionResult> RentCar(RentRequestDto rentRequestDto)
        {
            await _rentalService.RentCar(rentRequestDto);
            return Ok();
        }

        [HttpDelete("DeleteRental")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            await _rentalService.DeleteRental(id);
            return Ok();
        }

        [HttpGet("RentalReports")]
        public async Task<IActionResult> GetRentalReports(DateTime? fromDate, DateTime? toDate)
        {
            var report = await _rentalService.GetRentalsReport(fromDate, toDate);
            return Ok(report);
        }


        [HttpGet("MonthlyRentalReport")]
        public async Task<IActionResult> MonthlyRentalReport()
        {
            var report = await _rentalService.MonthlyRentalReport();
            return Ok(report);
        }
    }
}

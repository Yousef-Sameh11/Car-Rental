using CarRentalSystem.Dtos.CountryDtos;
using CarRentalSystem.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers.CountryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountries();
            return Ok(countries);
        }

        [HttpGet("GetCountryById/{countryId}")]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            var country = await _countryService.GetCountryById(countryId);
            return Ok(country);
        }

        [HttpPost("AddCountry")]
        public async Task<IActionResult> AddCountry(CountryRequestDto countryRequestDto)
        {
            await _countryService.AddCountry(countryRequestDto);
            return Ok($"Succesfully Created Country :{countryRequestDto.Name}");
        }

        [HttpDelete("DeleteCountry/{countryId}")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            await _countryService.DeleteCountry(countryId);
            return Ok("Deleted Country");
        }

    }

}

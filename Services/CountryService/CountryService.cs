using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Dtos.CountryDtos;
using CarRentalSystem.IServices;
using CarRentalSystem.Models.CountryModels;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CountryService(Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddCountry(CountryRequestDto countryRequestDto)
        {
            var country = _mapper.Map<Country>(countryRequestDto);
            _context.Add(country);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteCountry(int countryId)
        {
            var countryToBeDeleted = await _context.Countries.Where(i => i.Id == countryId).FirstOrDefaultAsync();
            _context.Countries.Remove(countryToBeDeleted);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<CountryResponseDto>> GetAllCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            var countriesDto = _mapper.Map<List<CountryResponseDto>>(countries);
            return countriesDto;
        }

        public async Task<CountryResponseDto> GetCountryById(int countryId)
        {
            var country = await _context.Countries.Where(i => i.Id == countryId).FirstOrDefaultAsync();
            var mapper = _mapper.Map<CountryResponseDto>(country);
            return mapper;
        }
    }
}

using CarRentalSystem.Dtos.CountryDtos;

namespace CarRentalSystem.IServices
{
    public interface ICountryService
    {
        Task<ICollection<CountryResponseDto>> GetAllCountries();
        Task<CountryResponseDto> GetCountryById(int countryId);

        Task AddCountry(CountryRequestDto countryRequestDto);

        Task DeleteCountry(int countryId);
    }
}

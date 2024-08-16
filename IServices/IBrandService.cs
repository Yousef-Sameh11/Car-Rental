using CarRentalSystem.Dtos.BrandDtos;
using CarRentalSystem.Models.BrandModel;

namespace CarRentalSystem.IServices
{
    public interface IBrandService
    {
        Task<ICollection<ResponseBrandDto>> GetAllBrandsAsync();

        Task<ICollection<BrandCarsDto>> GetAllBrandCarsAsync();
        Task <BrandCarsDto> GetBrandCarsAsync(int brandId);
        Task AddBrand(BrandRequestDto brandRequestDto);

        Task RemoveBrand(int brandId);
        Task<ResponseBrandDto> GetBrandById(int brandId);

    }
}

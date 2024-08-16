using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Dtos.BrandDtos;
using CarRentalSystem.IServices;
using CarRentalSystem.Models.BrandModel;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public BrandService(Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddBrand(BrandRequestDto brandRequestDto)
        {
           var brand = _mapper.Map<Brand>(brandRequestDto);
            _context.Add(brand);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BrandCarsDto>> GetAllBrandCarsAsync()
        {
            var brands = await _context.Brands.Include(c => c.cars).ToListAsync();

            var brandsDto = _mapper.Map<List<BrandCarsDto>>(brands);
            return brandsDto;
        }

        public async Task<ICollection<ResponseBrandDto>> GetAllBrandsAsync()
        {
            var brands = await _context.Brands.ToListAsync();

           var brandsDto=  _mapper.Map<List<ResponseBrandDto>>(brands);  
            return  brandsDto;
        }

        public async Task<ResponseBrandDto> GetBrandById(int brandId)
        {
            var brand = await _context.Brands.Where(d => d.Id == brandId).FirstOrDefaultAsync();
            var brandDto = _mapper.Map<ResponseBrandDto>(brand);
            return brandDto;
        }

        public async Task<BrandCarsDto> GetBrandCarsAsync(int brandId)
        {
            var brand = await _context.Brands.Where(d => d.Id == brandId).Include(c=>c.cars).FirstOrDefaultAsync();
            var brandDto = _mapper.Map<BrandCarsDto>(brand);
            return brandDto;
        }

        public Task RemoveBrand(int brandId)
        {
            throw new NotImplementedException();
        }
    }
}

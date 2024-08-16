using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Dtos.CarDtos;
using CarRentalSystem.Dtos.CategoryDtos;
using CarRentalSystem.IServices;
using CarRentalSystem.Models.CarCategoryModel;
using CarRentalSystem.Models.Cars;
using CarRentalSystem.Services.BrandServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;

namespace CarRentalSystem.Services.CarServices
{
    public class CarService : ICarService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly BrandService _brandService;

        public CarService(Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
         
        }
        public async Task AddCar(CarRequestDto carRequestDto)
        {
            var brand = await _context.Brands.Where(b => b.Id == carRequestDto.BrandId).FirstOrDefaultAsync();
          
            if (brand == null)
            {
                throw new ArgumentException("Brand Not Found");
            }
            var car = new Car
            {
                Brand = brand,
                BrandId = carRequestDto.BrandId,
                Name = carRequestDto.CarName,
                Model = carRequestDto.CarModel,
                Description = carRequestDto.CarDescription,
                Price = carRequestDto.CarPrice,
                Picture = carRequestDto.CarPicture,
                Availability = carRequestDto.Availability

            };

            _context.Add(car);
            _context.SaveChanges();

            foreach (var categoryId in carRequestDto.CategoryIds)
            {
                var category = await _context.Categories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();
                if (category == null)
                {
                    throw new ArgumentException("Category Not Found");
                }
                var CarCategory = new CarCategories
                {
                    Car = car,
                    Category = category
                };
                _context.CarCategories.Add(CarCategory);
            }
           

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCar(int carId)
        {
            var carToBeDeleted= await _context.Cars.Where(c => c.Id == carId).FirstOrDefaultAsync();
            _context.Cars.Remove(carToBeDeleted);
            await _context.SaveChangesAsync();

        }

        public async Task<ICollection<CarDto>> GetAllCars()
        {
            var cars =await _context.Cars
                .Where(c=>c.Availability > 0)
                .Include(b=>b.Brand)
                .Include(c=>c.CarCategories)
                .ThenInclude(c=>c.Category)
                .ToListAsync();
            var CarsDto = _mapper.Map<List<CarDto>>(cars);
            return CarsDto;
        }

        public async Task<List<CarDto>>GetAllCarsByBrandId(int brandId)
        {
            var cars = await _context.Cars
                .Where(c => c.Brand.Id == brandId)
                 .Include(c=>c.CarCategories)
                 .ThenInclude(c=>c.Category)
                 .Include(c=>c.Brand)
                .ToListAsync();
            var CarsDto = _mapper.Map<List<CarDto>>(cars);
            return CarsDto;
        }

        public async Task<List<CarDto>> GetAllCarsByBrandName(string brandName)
        {
           var cars = await _context.Cars.
                Where(c=>c.Brand.Name == brandName)
                .Include(c => c.CarCategories)
                 .ThenInclude(c => c.Category)
                 .Include(c => c.Brand)
                .ToListAsync();
            var CarsDto = _mapper.Map<List<CarDto>>(cars);
            return CarsDto;
        }
        public async Task<List<CarDto>> GetAllCarsByCategoryId(int categoryId)
        {
            var CarCategories =await _context.CarCategories
                .Where(c => c.CategoryId == categoryId)
                .Select(c=>new CarDto
                {   BrandId= c.Car.BrandId,
                    BrandName = c.Car.Brand.Name,
                    Id = c.CarId,
                    Name = c.Car.Name,
                    Picture = c.Car.Picture,
                    Model = c.Car.Model,
                    Price = c.Car.Price
                }) .ToListAsync();

            return CarCategories;

        }
        public async Task<CarDto> GetCarById(int carId)
        {
            var car = await _context.Cars
                .Include(d=>d.Brand)
               .Include(c=>c.CarCategories)
               .ThenInclude(c=>c.Category)
               .FirstOrDefaultAsync(c => c.Id == carId);
            var carDto = _mapper.Map<CarDto>(car);
            return carDto;
        }

        public async Task<CarDto> GetCarByName(string carName)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Name == carName);
            var carDto = _mapper.Map<CarDto>(car);
            return carDto;

        }

        public Task UpdateCar(CarRequestDto carRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}

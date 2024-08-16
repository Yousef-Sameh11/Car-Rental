using CarRentalSystem.Dtos.CarDtos;

namespace CarRentalSystem.IServices
{
    public interface ICarService
    {
        Task<ICollection<CarDto>> GetAllCars();

        Task<CarDto> GetCarById(int carId);
        Task<List<CarDto>> GetAllCarsByCategoryId(int categoryId);
        Task<CarDto> GetCarByName(string carName);
        Task<List<CarDto>> GetAllCarsByBrandId(int brandId);

        Task<List<CarDto>> GetAllCarsByBrandName(string brandName);

        Task AddCar(CarRequestDto carRequestDto);

        Task DeleteCar(int carId);

        Task UpdateCar(CarRequestDto carRequestDto);

    }
}

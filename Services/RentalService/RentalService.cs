using AutoMapper;
using CarRentalSystem.Data;
using CarRentalSystem.Dtos.RentalDtos;
using CarRentalSystem.IServices;
using CarRentalSystem.Models.RentalModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRentalSystem.Services.RentalService
{
    public class RentalService : IRentalService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public RentalService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task DeleteRental(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<RentResponseDto>> GetAllRentals()
        {
            var rentals = await _context.Rentals
                .Include(c => c.Car)
                .ThenInclude(b => b.Brand)
                .Include(u => u.User)
                .ToListAsync();
            var rentalsDto = _mapper.Map<List<RentResponseDto>>(rentals);
            return rentalsDto;
        }

        public async Task<ICollection<RentResponseDto>> GetAllUserRentals(int userId)
        {
            var rentals = await _context.Rentals
                .Include(c => c.Car)
                .ThenInclude(b => b.Brand)
                .Include(u => u.User)
                .Where(u => u.UserId == userId)
                .ToListAsync();
            var rentalsDto = _mapper.Map<List<RentResponseDto>>(rentals);
            return rentalsDto;
        }

        public async Task<RentResponseDto> GetRentalById(int id)
        {
            var rental = await _context.Rentals.Where(i => i.Id == id).FirstOrDefaultAsync();
            var rentalDto = _mapper.Map<RentResponseDto>(rental);
            return rentalDto;
        }

        public async Task RentCar(RentRequestDto rentRequestDto)
        {
            var user = await _context.Users.Where(i => i.Id == rentRequestDto.UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            var car = await _context.Cars.Where(c => c.Id == rentRequestDto.CarId).FirstOrDefaultAsync();
            if (car == null)
            {
                throw new Exception("Car Not Found");
            }
            var rental = new Rental
            {
                Car = car,
                RentDate = rentRequestDto.RentDate,
                ReturnDate = rentRequestDto.ReturnDate,
                User = user
            };
            car.Availability--;
            _context.Update(car);
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RentalsReportDto>> GetRentalsReport(DateTime? fromDate, DateTime? toDate)
        {
            DateTime startDate = fromDate.HasValue ? fromDate.Value.Date : DateTime.MinValue.Date;
            DateTime endDate = toDate.HasValue ? toDate.Value.Date.AddDays(1) : DateTime.MaxValue.Date;
            //DateTime endDate = toDate.HasValue ? toDate.Value.Date.AddDays(1) : DateTime.Now.Date.AddDays(1);

            var rentalsReport = await _context.Rentals
                .Where(d => d.RentDate >= startDate && d.RentDate <= endDate)
                .GroupBy(d => d.RentDate.Date)
                .Select(r => new RentalsReportDto
                {
                    Date = r.Key,
                    Rentals = r.Select(c => new RentResponseDto
                    {
                        BrandId = c.Car.BrandId,
                        BrandName = c.Car.Brand.Name,
                        CarId = c.CarId,
                        CarModel = c.Car.Model,
                        CarName = c.Car.Name,
                        RentalId = c.Id,
                        RentalPrice = c.RentalPrice,
                        RentDate = c.RentDate,
                        ReturnDate = c.ReturnDate,
                        UserFullName = c.User.Name,
                        UserId = c.UserId
                    }).ToList(),
                }).ToListAsync();


            return rentalsReport;
        }

        public async Task<List<RentalsReportDto>> MonthlyRentalReport()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = DateTime.Now;

            var monthlyRentalReport = await _context.Rentals
                .Where(r => r.RentDate >= startOfMonth && r.RentDate <= endDate)
                .GroupBy(d => d.RentDate.Date)
                .Select(r => new RentalsReportDto
                {
                    Date = r.Key,
                    Rentals = r.Select(c => new RentResponseDto
                    {
                        BrandId = c.Car.BrandId,
                        BrandName = c.Car.Brand.Name,
                        CarId = c.CarId,
                        CarModel = c.Car.Model,
                        CarName = c.Car.Name,
                        RentalId = c.Id,
                        RentalPrice = c.RentalPrice,
                        RentDate = c.RentDate,
                        ReturnDate = c.ReturnDate,
                        UserFullName = c.User.Name,
                        UserId = c.UserId
                    }).ToList(),
                }).ToListAsync();
            return monthlyRentalReport;
        }

    }
}

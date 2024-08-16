using CarRentalSystem.Dtos.RentalDtos;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CarRentalSystem.IServices
{
    public interface IRentalService
    {
        Task RentCar(RentRequestDto rentRequestDto);
        Task<ICollection<RentResponseDto>> GetAllRentals();
        Task<RentResponseDto> GetRentalById(int id);
        Task<ICollection<RentResponseDto>> GetAllUserRentals(int userId);
        Task<List<RentalsReportDto>> GetRentalsReport(DateTime? fromDate, DateTime? toDate);
         Task<List<RentalsReportDto>> MonthlyRentalReport();
        Task DeleteRental(int id);



    }
}

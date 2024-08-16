using CarRentalSystem.Models.Cars;
using CarRentalSystem.Models.UserModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentalSystem.Dtos.RentalDtos
{
    public class RentResponseDto
    {
        public int RentalId { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarModel {  get; set; }
        public decimal RentalPrice { get; set; }

     
        


    }
}

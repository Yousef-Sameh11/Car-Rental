using CarRentalSystem.Models.Cars;
using CarRentalSystem.Models.UserModels;

namespace CarRentalSystem.Dtos.RentalDtos
{
    public class RentRequestDto
    {
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
      
    }
}

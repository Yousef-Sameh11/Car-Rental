using CarRentalSystem.Models.Cars;
using CarRentalSystem.Models.UserModels;
using System.Diagnostics.Contracts;

namespace CarRentalSystem.Models.RentalModels
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal RentalPrice {  get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }  
        
    }
}

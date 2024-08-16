using CarRentalSystem.Models.UserModels;

namespace CarRentalSystem.Models.CountryModels
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users {  get; set; }

    }
}

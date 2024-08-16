﻿using CarRentalSystem.Models.CountryModels;
using CarRentalSystem.Models.RentalModels;

namespace CarRentalSystem.Models.UserModels
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public Country Country { get; set; }
        public ICollection<Rental> UserRentals { get; set; }
    }
}

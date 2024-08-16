using CarRentalSystem.Models.BrandModel;
using CarRentalSystem.Models.CarCategoryModel;
using CarRentalSystem.Models.Cars;
using CarRentalSystem.Models.CategoryModels;
using CarRentalSystem.Models.CountryModels;
using CarRentalSystem.Models.RentalModels;
using CarRentalSystem.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CarCategories> CarCategories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Rental>Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarCategories>()
                .HasKey(k => new { k.CarId, k.CategoryId });

            modelBuilder.Entity<CarCategories>()
                .HasOne(ca => ca.Car)
                .WithMany(cc => cc.CarCategories)
                .HasForeignKey(c => c.CarId);

            modelBuilder.Entity<CarCategories>()
              .HasOne(cr => cr.Category)
              .WithMany(cc => cc.CarCategories)
              .HasForeignKey(c => c.CategoryId);

        }
    }


}

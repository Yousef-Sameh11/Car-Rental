using AutoMapper;
using CarRentalSystem.Dtos.BrandDtos;
using CarRentalSystem.Dtos.CarDtos;
using CarRentalSystem.Dtos.CategoryDtos;
using CarRentalSystem.Dtos.CountryDtos;
using CarRentalSystem.Dtos.RentalDtos;
using CarRentalSystem.Models.BrandModel;
using CarRentalSystem.Models.CarCategoryModel;
using CarRentalSystem.Models.Cars;
using CarRentalSystem.Models.CategoryModels;
using CarRentalSystem.Models.CountryModels;
using CarRentalSystem.Models.RentalModels;

namespace CarRentalSystem.Helpers.MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {    //Brand
            CreateMap<ResponseBrandDto, Brand>().ReverseMap();
            CreateMap<BrandRequestDto, Brand>();

            CreateMap<BrandCarsDto, Brand>().ReverseMap();


            //Car
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.CarCategories.Select(d => new CategoryDto
                {
                    Id = d.CategoryId,
                    Name = d.Category.Name
                }))).ReverseMap();

          
            //Category
            CreateMap<CategoryDto, Category>().ReverseMap();

            //Country
            CreateMap<CountryResponseDto, Country>().ReverseMap();
            CreateMap<Country, CountryRequestDto>().ReverseMap();

            //Rental
            CreateMap<Rental, RentResponseDto>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.RentalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CarName, opt => opt.MapFrom(src => src.Car.Name))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Car.Model))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Car.BrandId))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name));


        }

    }
}

namespace CarRentalSystem.Dtos.CarDtos
{
    public class CarRequestDto
    {
        public string CarName { get; set; }

        public string CarDescription { get; set; }

        public string CarModel { get; set; }

        public string CarPicture {  get; set; }
        public decimal CarPrice { get; set; }
        public int Availability { get; set; }
        public int BrandId {  get; set; }

        
        public ICollection <int> CategoryIds {  get; set; }

       
    }
}

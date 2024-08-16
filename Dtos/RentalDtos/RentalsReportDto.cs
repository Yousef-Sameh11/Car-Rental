namespace CarRentalSystem.Dtos.RentalDtos
{
    public class RentalsReportDto
    {
        public DateTime? Date { get; set; }
        public ICollection<RentResponseDto> Rentals { get; set; }

    }
}

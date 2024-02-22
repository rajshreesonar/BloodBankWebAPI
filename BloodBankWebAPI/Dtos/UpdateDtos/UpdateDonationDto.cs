using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Dtos.UpdateDtos
{
    public class UpdateDonationDto
    {
        public int DonorId { get; set; }
        public Donor Donor { get; set; }
        public DateTime DonationDate { get; set; }
        public string BloodType { get; set; }
        public int Quantity_ML { get; set; }
    }
}

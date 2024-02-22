using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Dtos.GetDtos
{
    public class GetDonationDto
    {
        public int Id { get; set; }
     //   public int DonorId { get; set; }
        public Donor Donor { get; set; }
        public DateTime DonationDate { get; set; }
        public string BloodType { get; set; }
        public int Quantity_ML { get; set; }
    }
}

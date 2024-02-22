using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Dtos.UpdateDtos
{
    public class UpdateBloodInventoryDto
    {
        public int Id { get; set; }

        //    [ForeignKey("Donation")]
        public int DonationId { get; set; }
       // public Donation Donation { get; set; }
        public string BloodType { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}

using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Dtos.AddDtos
{
    public class AddTransfusionDto
    {
        public int RecipientId { get; set; }
        public int BloodInventoryId { get; set; }
        public DateTime? TransfusionDate { get; set; }
        public int Quantity { get; set; }
        public int HospitalId { get; set; }
    }
}

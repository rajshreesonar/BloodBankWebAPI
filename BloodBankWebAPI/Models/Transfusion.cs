using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankWebAPI.Models
{
    public class Transfusion
    {
        public int Id { get; set; }
        public int RecipientId {  get; set; }
        public Recipient Recipient { get; set; }
        public int BloodInventoryId { get; set; }
        public BloodInventory BloodInventory { get; set; }
        public DateTime? TransfusionDate { get; set; }
        public int Quantity { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}

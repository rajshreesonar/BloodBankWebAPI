using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankWebAPI.Models
{
    public class Donation
    {
        public int ID { get; set; }

   //     [ForeignKey("Donor")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; }
        public DateTime DonationDate { get; set; }   
        public string BloodType {  get; set; }
        public int Quantity_ML { get; set;}

    }
}


namespace BloodBankWebAPI.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public string Contact { get; set; }
        public DateTime LastDonationDate { get; set; }= DateTime.Now;
        public string HealthStatus { get; set; }

    }
}

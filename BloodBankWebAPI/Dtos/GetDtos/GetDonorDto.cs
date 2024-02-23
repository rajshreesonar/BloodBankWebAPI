namespace BloodBankWebAPI.Dtos.GetDtos
{
    public class GetDonorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public string Contact { get; set; }
        public DateTime LastDonationDate { get; set; }
        public string HealthStatus { get; set; }
        //public IFormFile adharCard { get; set; }
    }
}

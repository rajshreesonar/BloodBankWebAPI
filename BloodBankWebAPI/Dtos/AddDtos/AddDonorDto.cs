namespace BloodBankWebAPI.Dtos.AddDtos
{
    public class AddDonorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public string Contact { get; set; }
        public string HealthStatus { get; set; }
        public IFormFile adharUpload { get; set; }

    }
}

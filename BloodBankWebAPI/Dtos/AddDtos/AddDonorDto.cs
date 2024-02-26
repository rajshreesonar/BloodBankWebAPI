using System.ComponentModel.DataAnnotations;

namespace BloodBankWebAPI.Dtos.AddDtos
{
    public class AddDonorDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string BloodType { get; set; }
        [Required]
        [Phone]
        public string Contact { get; set; }
        [Required]
        public string HealthStatus { get; set; }
        [Required]
        public IFormFile adharUpload { get; set; }

    }
}

namespace BloodBankWebAPI.Dtos.AddDtos
{
    public class AddRecipientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public int Quantity { get; set; }
        public string Contact { get; set; }
        public int HospitalId { get; set; }

    }
}

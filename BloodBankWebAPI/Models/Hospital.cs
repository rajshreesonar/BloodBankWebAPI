namespace BloodBankWebAPI.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Contact {  get; set; }

        public void UpdateHospital(string? name, int contact)
        {
            Name = name;
            Contact = contact;
        }
    }
}

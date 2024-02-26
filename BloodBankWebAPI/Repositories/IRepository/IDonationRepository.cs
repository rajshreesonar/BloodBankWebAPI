using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IDonationRepository
    {
        void AddDonation(AddDonationDto donation);
        void UpdateDonation(UpdateDonationDto donation);
        IEnumerable<GetDonationDto> GetDonations();
      //  byte[] GetDonationPdf();
    }
}

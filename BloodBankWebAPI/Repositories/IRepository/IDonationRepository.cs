using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IDonationRepository
    {
        Task<int> AddDonation(AddDonationDto donation);
        void UpdateDonation(UpdateDonationDto donation);
        Task<IEnumerable<GetDonationDto>> GetDonations();
      //  byte[] GetDonationPdf();
    }
}

using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IDonationRepository
    {
        Task<int> AddDonation(Donation donation);
        void UpdateDonation(Donation donation);
        Task<IEnumerable<Donation>> GetDonations();
      //  byte[] GetDonationPdf();
    }
}

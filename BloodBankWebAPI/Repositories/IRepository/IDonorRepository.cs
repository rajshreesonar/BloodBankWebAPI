using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IDonorRepository
    {
        void AddDonor(AddDonorDto addDonor);
        void UpdateDonor(UpdateDonorDto updateDonor);

        Task<IEnumerable<Donor>> GetAllDonors();

    }
}

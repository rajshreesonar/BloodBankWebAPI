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
        Task<int> AddDonor(Donor addDonor);
        Task<int> UpdateDonor(Donor updateDonor);
        Task<IEnumerable<Donor>> GetAllDonors();

    }
}

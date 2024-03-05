using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IHospitalRepository
    {
        Task<int> AddHospital(Hospital addHospital);
        Task<int> UpdateHospital(Hospital updateHospital);
        Task<IEnumerable<Hospital>> GetHospitals();
        Task<Hospital> GetHospitalById(int id);

    }
}

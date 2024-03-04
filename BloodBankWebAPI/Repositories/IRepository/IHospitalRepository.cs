using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IHospitalRepository
    {
        Task<int> AddHospital(AddHospitalDto addHospital);
        Task<int> UpdateHospital(UpdateHospitalDto updateHospital);
        Task<IEnumerable<GetHospitalDto>> GetHospitals();


    }
}

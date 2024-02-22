using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IHospitalRepository
    {
        void AddHospital(AddHospitalDto addHospital);

        void UpdateHospital(UpdateHospitalDto updateHospital);

        IEnumerable<GetHospitalDto> GetHospitals();


    }
}

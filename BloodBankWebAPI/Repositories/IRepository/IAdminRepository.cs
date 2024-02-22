using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IAdminRepository
    {
        void AddAdmin(Admin admin);
        IEnumerable<GetAdminDto> GetAdmin();
        IEnumerable<Admin> Login(string username);

        bool AleadyRegister(string username);
    }
}

using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IAdminRepository
    {
        void AddAdmin(Admin admin);
        Task<IEnumerable<Admin>> GetAdmin();
        IEnumerable<Admin> Login(string username);

        bool AleadyRegister(string username);
    }
}

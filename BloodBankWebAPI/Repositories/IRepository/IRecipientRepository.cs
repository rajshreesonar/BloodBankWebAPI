using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IRecipientRepository
    {
        Task<int> AddRecipient(AddRecipientDto addRecipient);
        void UpdateRecipient(UpdateRecipientDto Updaterecipient);
        Task<IEnumerable<GetRecipientDto>> GetAllRecipients();

    }
}

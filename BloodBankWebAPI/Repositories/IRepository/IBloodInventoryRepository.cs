using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IBloodInventoryRepository
    {
        Task<int> AddBloodInventory(AddBloodInventoryDto addBloodInventory);
        void UpdateBloodInventory(UpdateBloodInventoryDto updateBloodInventory);
        IEnumerable<GetBloodInventoryDto> GetBloodInventories();
    }   
}

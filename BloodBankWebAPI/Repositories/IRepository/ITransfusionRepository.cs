using System.Transactions;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Models;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface ITransfusionRepository
    {
        Task AddTransfusion(AddTransfusionDto transfusion);
    }
}

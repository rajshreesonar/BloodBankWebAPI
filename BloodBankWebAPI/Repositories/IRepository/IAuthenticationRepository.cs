using Azure.Core;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IAuthenticationRepository
    {
        void CreatePasswordHash(string Password, out byte[] passwordHash, out byte[] passwordSalt);

    }
}   

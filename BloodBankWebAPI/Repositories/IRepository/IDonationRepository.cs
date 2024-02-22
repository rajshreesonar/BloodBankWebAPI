using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;

namespace BloodBankWebAPI.Repositories.IRepository
{
    public interface IDonationRepository
    {
        void AddDonation(AddDonationDto donation);
        void UpdateDonation(UpdateDonationDto donation);

        IEnumerable<GetDonationDto> GetDonations();
    }
}

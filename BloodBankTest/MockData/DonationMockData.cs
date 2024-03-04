using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankWebAPI.Dtos.GetDtos;

namespace BloodBankTest.MockData
{
    public class DonationMockData
    {
        public static async Task<IEnumerable<GetDonationDto>> GetMockDonation()
        {
            var donationList = new List<GetDonationDto>()
            {
                new GetDonationDto()
                {
                    DonationDate= DateTime.Now,
                    BloodType = "B+",
                    Quantity_ML = 100
                }
            };
            return donationList;
        }
    }
}

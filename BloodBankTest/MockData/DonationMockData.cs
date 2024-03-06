using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;

namespace BloodBankTest.MockData
{
    public class DonationMockData
    {
        public static async Task<IEnumerable<Donation>> GetMockDonation()
        {
            var donationList = new List<Donation>()
            {
                new Donation()
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

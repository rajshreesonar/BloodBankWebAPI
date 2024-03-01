using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;

namespace BloodBankTest.MockData
{
    public class DonorMockData
    {
        public static async Task<IEnumerable<Donor>> GetMockDonors()
        {
            var donorList = new List<Donor>()
            {
                new Donor()
                {
                   Id= 1,
                   FirstName= "Rajshree",
                   LastName= "Sonar",
                   Dob= DateTime.Now,
                   Gender= "Female",
                   BloodType= "O+",
                   Contact= "99033443321",
                   LastDonationDate= DateTime.Now,
                   HealthStatus= "Healthy"
                }
            };

            return donorList;
        }
    }
}

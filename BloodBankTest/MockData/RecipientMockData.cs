using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankTest.MockData
{
    public class RecipientMockData
    {
        public static async Task<IEnumerable<GetRecipientDto>> GetMockRecipient()
        {
            var recipientList = new List<GetRecipientDto>()
            {
                new GetRecipientDto()
                {
                   Id= 1,
                   FirstName= "shree",
                   LastName= "Patil",
                   DOB= DateTime.Now,
                   Gender= "Female",
                   BloodType= "O+",
                   Quantity= 200,
                   Contact= "99033443321",
                   HospitalId= 1,
                },
                new GetRecipientDto()
                {
                   Id= 2,
                   FirstName= "Jayshree",
                   LastName= "Sane",
                   DOB= DateTime.Now,
                   Gender= "Female",
                   BloodType= "O+",
                   Quantity= 200,
                   Contact= "99033443321",
                   HospitalId= 1,
                }
            };

            return recipientList;
        }
    }
}

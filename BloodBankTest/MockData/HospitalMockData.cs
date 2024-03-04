using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;

namespace BloodBankTest.MockData
{
    public class HospitalMockData
    {
        public async static Task<List<GetHospitalDto>> GetMockHospital()
        {
            var hospitalList = new List<GetHospitalDto>()
            {
                new GetHospitalDto()
                {
                    Id = 1,
                    Name = "Test",
                    Contact = 2323554
                }

            };

            return hospitalList;
        }
    }
}

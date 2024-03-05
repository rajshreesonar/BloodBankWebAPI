using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;

namespace BloodBankTest.MockData
{
    public class AdminMockData
    {
        public static async Task<IEnumerable<Admin>> GetMockAdminData()
        {
            var adminList = new List<Admin>()
            {
                new Admin()
                { Id = 1,FirstName="Parth",LastName="Ghusar"}
            };
            return adminList;
        }
    }
}

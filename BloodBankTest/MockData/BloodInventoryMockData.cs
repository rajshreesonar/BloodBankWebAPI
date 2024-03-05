using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;

namespace BloodBankTest.MockData
{
    public class BloodInventoryMockData
    {
        public static async Task<IEnumerable<BloodInventory>> GetMockBloodInventory()
        {
            var bloodInventoryList = new List<BloodInventory>()
            {
                new BloodInventory()
                {
                    Id = 1,
                    BloodType= "B+",
                    Quantity = 1,
                    ExpiryDate = DateTime.Now,
                }
                 
            };
            return bloodInventoryList;
        }
    }
}

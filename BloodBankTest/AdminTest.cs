using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodBankTest.MockData;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BloodBankTest
{
    public class AdminTest
    {
        [Fact]
        public async void GetAdminTest()
        {
            var adminMockRepo = new Mock<IAdminRepository>();
            adminMockRepo.Setup(i => i.GetAdmin()).ReturnsAsync(await AdminMockData.GetMockAdminData());

            AdminController adminController= new AdminController(adminMockRepo.Object, new Mock<IMapper>().Object);

            var data = await adminController.GetAdmin();
            var result = data as ObjectResult;

            Assert.NotNull(data);
            Assert.Equal(200, result.StatusCode);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankTest.MockData;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BloodBankTest
{
    public class HospitalTest
    {
        AddHospitalDto addHospitalDto = new AddHospitalDto()
        {
            Name = "Test",
            Contact = 2323554
        };
        [Fact]
        public async void AddHospitalTest()
        {
            var hospitalMockRepo = new Mock<IHospitalRepository>();
            hospitalMockRepo.Setup(i=>i.AddHospital(addHospitalDto));

            HospitalController hospitalController = new HospitalController( hospitalMockRepo.Object );
          

            var data= await hospitalController.AddHospital(addHospitalDto);
            var result = data as OkObjectResult;
            Assert.NotNull(result);
           // Assert.Equal(204, result.StatusCode);
        }

        UpdateHospitalDto updateHospitalDto = new UpdateHospitalDto()
        {
            Name = "Test1",
            Contact = 111111
        };
        [Fact]
        public async void UpdateHospitalTest()
        {
            var hospitalMockRepo = new Mock<IHospitalRepository>();
            hospitalMockRepo.Setup(i => i.UpdateHospital(updateHospitalDto));

            HospitalController hospitalController = new HospitalController(hospitalMockRepo.Object);

            var data = await hospitalController.UpdateHospital(updateHospitalDto);
            var result = data as OkObjectResult;    
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void GetHospitalTest()
        {
            var hospitalMockRepo = new Mock<IHospitalRepository>();
            hospitalMockRepo.Setup(i =>i.GetHospitals()).ReturnsAsync(await HospitalMockData.GetMockHospital());

            HospitalController hospitalController = new HospitalController(hospitalMockRepo.Object);

            var data = await hospitalController.GetHospitals();
            var result = data as OkObjectResult;    
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

    }
}

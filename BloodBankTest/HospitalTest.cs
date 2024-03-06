using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodBankTest.MockData;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Models;
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
        Hospital hospital = new Hospital()
        {
            Id=1,
            Name = "Test",
            Contact = 2323554
        };

        [Fact]
        public async void AddHospitalTest()
        {
            var hospitalMockRepo = new Mock<IHospitalRepository>();
            hospitalMockRepo.Setup(i=>i.AddHospital(hospital));

            HospitalController hospitalController = new HospitalController(hospitalMockRepo.Object, new Mock<IMapper>().Object );

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
        Hospital updatedhospital = new Hospital()
        {
            Id = 1,
            Name = "Test1",
            Contact = 111111
        };

        [Fact]
        public async void UpdateHospitalTest()
        {
            var hospitalMockRepo = new Mock<IHospitalRepository>();
            hospitalMockRepo.Setup(i => i.UpdateHospital(updatedhospital));

            HospitalController hospitalController = new HospitalController(hospitalMockRepo.Object, new Mock<IMapper>().Object);

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

            HospitalController hospitalController = new HospitalController(hospitalMockRepo.Object, new Mock<IMapper>().Object);

            var data = await hospitalController.GetHospitals();
            var result = data as OkObjectResult;    
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void GetHospitalByIdTest()
        {
            var hospitalMockRepo = new Mock<IHospitalRepository>();
            hospitalMockRepo.Setup(i => i.GetHospitalById(1)).ReturnsAsync((await HospitalMockData.GetMockHospital())[0]);

            HospitalController hospitalController = new HospitalController(hospitalMockRepo.Object, new Mock<IMapper>().Object);

            var data = await hospitalController.GetHospitalById(1);
            var result = data as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void GetHospitalById_NotFoundTest()
        {
            var hospitalMockRepo = new Mock<IHospitalRepository>();
            hospitalMockRepo.Setup(i => i.GetHospitalById(4)).ReturnsAsync((Hospital)null);

            HospitalController hospitalController = new HospitalController(hospitalMockRepo.Object, new Mock<IMapper>().Object);

            var data = await Assert.ThrowsAsync<NotFoundException>(()=> hospitalController.GetHospitalById(4));
         
            Assert.Equal("Id is not available", data.Message);
        }

    }
}

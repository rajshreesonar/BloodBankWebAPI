using AutoMapper;
using BloodBankTest.MockData;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace BloodBankTest
{
    public class DonorTest
    {
        [Fact]
        public async void GetTest()
        {
            var options = new DbContextOptionsBuilder<BloodBankContext>().Options;
            var contextMock = new Mock<BloodBankContext>(options);

            var donorMockRepository = new Mock<IDonorRepository>();
            donorMockRepository.Setup(data => data.GetAllDonors()).ReturnsAsync(await DonorMockData.GetMockDonors());

            var mapperMock = new Mock<IMapper>();

            DonorController donorController = new DonorController(donorMockRepository.Object, new Mock<ILogger<DonorController>>().Object, new Mock<IHttpContextAccessor>().Object, contextMock.Object, mapperMock.Object);

            var data = await donorController.GetDonors();

            mapperMock.Setup(i => i.Map<IEnumerable<GetDonorDto>>(data)).Returns(new List<GetDonorDto>());

            var result = data as ObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void PostTest()
        {
            AddDonorDto addDonordto = new AddDonorDto()
            {
                FirstName = "Rajshree",
                LastName = "Sonar",
                Dob = DateTime.Now,
                Gender = "Female",
                BloodType = "O+",
                Contact = "99033443321",
                //  LastDonationDate= DateTime.Now,
                HealthStatus = "Healthy"
            };

            var options = new DbContextOptionsBuilder<BloodBankContext>().Options;
            var contextMock = new Mock<BloodBankContext>(options);

            var donorMockRepository = new Mock<IDonorRepository>();
            donorMockRepository.Setup(data => data.AddDonor(addDonordto));

         //   donorMockRepository.Setup(data => data.AddDonor(It.IsAny<AddDonorDto>())).ReturnsAsync(donor);


            DonorController donorController = new DonorController(donorMockRepository.Object, new Mock<ILogger<DonorController>>().Object, new Mock<IHttpContextAccessor>().Object, contextMock.Object, new Mock<IMapper>().Object);

            var data = await donorController.AddDonor(addDonordto);
            var result = data as OkObjectResult;

           // Assert.NotNull(data);
            Assert.Equal(200, result.StatusCode);
        }

        //[Fact]
        //public async void DownloadFileTest()
        //{
        //    var options = new DbContextOptionsBuilder<BloodBankContext>().Options;
        //    var contextMock = new Mock<BloodBankContext>(options);

        //    string url = "C:\\Users\\Rajshree\\Source\\Repos\\rajshreesonar\\BloodBankWebAPI\\BloodBankWebAPI\\uploads\\DonorData";

        //    DonorController donorController = new DonorController(new Mock<IDonorRepository>().Object, new Mock<ILogger<DonorController>>().Object, new Mock<IHttpContextAccessor>().Object, contextMock.Object, new Mock<IMapper>().Object);

        //    var data= await donorController.DownloadFile(url);

        //    Assert.NotNull(data);
        //    Assert.Equal(expectedBase64String, (IEnumerable<char>)data);

        //}

    }
}
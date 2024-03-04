using AutoMapper;
using BloodBankTest.MockData;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace BloodBankTest
{
    public class DonorTest
    {
        // [Fact]
        //public async void GetTest()
        //{
        //    var options = new DbContextOptionsBuilder<BloodBankContext>().Options;
        //    var contextMock = new Mock<BloodBankContext>(options);

        //    var donorMockRepository = new Mock<IDonorRepository>();
        //    donorMockRepository.Setup(data => data.GetAllDonors()).ReturnsAsync(DonorMockData.GetMockDonors());

        //    var mapperMock = new Mock<IMapper>();

        //    DonorController donorController = new DonorController(donorMockRepository.Object, new Mock<ILogger<DonorController>>().Object, new Mock<IHttpContextAccessor>().Object, contextMock.Object, mapperMock.Object);

        //    var data = await donorController.GetDonors();

        //    mapperMock.Setup(i => i.Map<IEnumerable<GetDonorDto>>(data)).Returns(new List<GetDonorDto>());

        //    var result = data as ObjectResult;
        //    Assert.Equal(200, result.StatusCode);
        //}

        //[Fact]
        //public async void PostTest()
        //{
        //    var donorMockRepository = new Mock<IDonorRepository>();
        //    donorMockRepository.Setup(data => data.AddDonor()).ReturnsAsync(DonorMockData.GetMockDonors());
        //}

    }
}
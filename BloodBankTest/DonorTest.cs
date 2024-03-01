using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BloodBankTest.MockData;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BloodBankTest
{
    //public class DonorTest
    //{
    //    [Fact]
    //    public async void Test1()
    //    {
    //        var donorMockRepository = new Mock<IDonorRepository>();
    //        donorMockRepository.Setup(data => data.GetAllDonors()).ReturnsAsync(await DonorMockData.GetMockDonors());

    //        DonorController donorController = new DonorController(donorMockRepository.Object, new Mock<ILogger<DonorController>>().Object, new Mock<IHttpContextAccessor>().Object, new Mock<BloodBankContext>().Object,new Mock<IMapper>().Object);

    //        var data = await donorController.GetDonors();
    //        var result = data as ObjectResult;
    //        Assert.NotNull(data);
    //    }
    //}
}
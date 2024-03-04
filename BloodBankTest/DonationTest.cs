using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankTest.MockData;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BloodBankTest
{
    public class DonationTest
    {
        AddDonationDto addDonationDto = new AddDonationDto()
        {
            DonorId=1,
            DonationDate= DateTime.Now,
            BloodType = "B+",
            Quantity_ML = 100,
        };


        [Fact]
        public async void AddDonationTest()
        {
            var options = new DbContextOptionsBuilder<BloodBankContext>().Options;
            var contextMock = new Mock<BloodBankContext>(options);

            var donationMockRepo = new Mock<IDonationRepository>();
            donationMockRepo.Setup(i => i.AddDonation(addDonationDto));

            DonationController donationController = new DonationController(donationMockRepo.Object, contextMock.Object);

            var data = await donationController.AddDonations(addDonationDto);
            var result = data as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void GetDonationTest()
        {
            var options = new DbContextOptionsBuilder<BloodBankContext>().Options;
            var contextMock = new Mock<BloodBankContext>(options);

            var donationMockResult = new Mock<IDonationRepository>();
            donationMockResult.Setup(i => i.GetDonations()).ReturnsAsync(await DonationMockData.GetMockDonation());

            DonationController donationController = new DonationController(donationMockResult.Object, contextMock.Object);

            var data= await donationController.GetDonations();
            var result = data as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }


    }
}

using AutoMapper;
using BloodBankTest.MockData;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SixLabors.ImageSharp.Processing;

namespace BloodBankTest
{
    public class RecipentTest
    {
        [Fact]
        public async void testGetAPI()
        {
            var recipientMockRepo = new Mock<IRecipientRepository>();
            recipientMockRepo.Setup(i => i.GetAllRecipients()).Returns(RecipientMockData.GetMockRecipient);

            RecipientController recipientController = new RecipientController(recipientMockRepo.Object, new Mock<IBloodInventoryRepository>().Object, new Mock<ITransfusionRepository>().Object,new Mock<IMapper>().Object);

            var data = await recipientController.GetRecipient();

            var result = data as ObjectResult;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async void AddRecipientTest()
        {
            AddRecipientDto addRecipientDto = new AddRecipientDto()
            {
                FirstName = "shree",
                LastName = "Patel",
                DOB = DateTime.Now,
                Gender = "Female",
                BloodType = "O+",
                Quantity = 200,
                Contact = "99033443321",
                HospitalId = 1,
            };

            AddTransfusionDto addTransfusionDto = new AddTransfusionDto()
            {
                RecipientId = 1,
                TransfusionDate = DateTime.Now,
                Quantity=200,
                HospitalId= 2
            };
            GetBloodInventoryDto getBloodInventoryDto = new GetBloodInventoryDto()
            {
                Id = 1,
                BloodType="O+",
                Quantity = 400,
                ExpiryDate= DateTime.Now,
            };
            var recipientMockRepo = new Mock<IRecipientRepository>();
            recipientMockRepo.Setup(i => i.AddRecipient(addRecipientDto));

            var transfusionMockRepo = new Mock<ITransfusionRepository>();
            transfusionMockRepo.Setup(i => i.AddTransfusion(addTransfusionDto));

            var inventoryMockRepo = new Mock<IBloodInventoryRepository>();
            inventoryMockRepo.Setup(i => i.GetBloodInventories());

            RecipientController recipientController = new RecipientController(recipientMockRepo.Object,inventoryMockRepo.Object, transfusionMockRepo.Object, new Mock<IMapper>().Object);

            var data = await recipientController.AddRecipient(addRecipientDto);

            var result = data as ObjectResult;
            Assert.NotNull(data);
        }

        [Fact]
        public async void UpdateTest()
        {
            UpdateRecipientDto updateRecipientDto = new UpdateRecipientDto()
            {
                FirstName = "shree",
                LastName = "Patel",
                DOB = DateTime.Now,
                Gender = "Female",
                BloodType = "O+",
                Quantity = 200,
                Contact = "99033443321",
                HospitalId = 1,
            };

            Recipient recipient = new Recipient()
            {
                Id = 10,
                FirstName = "shree",
                LastName = "Patel",
                DOB = DateTime.Now,
                Gender = "Female",
                BloodType = "O+",
                Quantity = 200,
                Contact = "99033443321",
                HospitalId = 1,
            };

            var recipientMockRepo= new Mock<IRecipientRepository>();
            recipientMockRepo.Setup(i => i.UpdateRecipient(recipient));
             
            RecipientController recipientController = new RecipientController(recipientMockRepo.Object, new Mock<IBloodInventoryRepository>().Object, new Mock<ITransfusionRepository>().Object, new Mock<IMapper>().Object);

            var data = recipientController.UpdateRecipient(updateRecipientDto);
            var result = data as ObjectResult;
            Assert.NotNull(data);
            Assert.Equal(200,result.StatusCode);
        }
    }
}

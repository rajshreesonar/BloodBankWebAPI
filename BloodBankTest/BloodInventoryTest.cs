using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BloodBankTest.MockData;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Mappers;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BloodBankTest
{
    public class BloodInventoryTest
    {
        private readonly IMapper _mapper;
        public BloodInventoryTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new BloodInventoryMapper());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async void GetBloodTest()
        {
            var bloodInventoryRepo = new Mock<IBloodInventoryRepository>();
            bloodInventoryRepo.Setup(i => i.GetBloodInventories()).ReturnsAsync(await BloodInventoryMockData.GetMockBloodInventory());

            BloodInventoryController bloodInventoryController = new BloodInventoryController(bloodInventoryRepo.Object,_mapper);

            var data = await bloodInventoryController.GetBloodInventory();
            var result = data as ObjectResult;

            Assert.NotNull(data);
            Assert.Equal(200, result.StatusCode);

        }
    }
}

using BloodBankTest.MockData;
using BloodBankWebAPI.Controllers;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BloodBankTest
{
    public class RecipentTest
    {
        //public void testGetAPI()
        //{
        //    var recipientMockRepo = new Mock<IRecipientRepository>();
        //    recipientMockRepo.Setup(i => i.GetAllRecipients()).Returns(RecipientMockData.GetMockRecipient);

        //    RecipientController recipientController = new RecipientController(recipientMockRepo.Object, new Mock<IBloodInventoryRepository>().Object, new Mock<ITransfusionRepository>().Object);

        //    var data = recipientController.GetRecipient();

        //    // Assert.NotNull(data);

        //    //// Check if data is of type ObjectResult
        //    //if (data is ObjectResult result)
        //    //{
        //    //    Assert.Equal(200, result.StatusCode);
        //    //}
        //    var result = data as Object;
        //    Assert.Equal(200, result);

        //}
    }
}

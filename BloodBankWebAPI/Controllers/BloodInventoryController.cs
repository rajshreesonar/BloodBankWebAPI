using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodInventoryController : ControllerBase
    {
        private readonly IBloodInventoryRepository _bloodInventoryRepository;

        public BloodInventoryController(IBloodInventoryRepository bloodInventoryRepository)
        {
            _bloodInventoryRepository = bloodInventoryRepository;
        }

        //[HttpPost("AddBloodInventory")]
        //public IActionResult AddBloodInventory(AddBloodInventoryDto addBloodInventory)
        //{
        //    _bloodInventoryRepository.AddBloodInventory(addBloodInventory);
        //   return Ok();
        //}

        //[HttpPut()]
        //public IActionResult UpdateBloodInventory(UpdateBloodInventoryDto updateBloodInventory)
        //{
        //    _bloodInventoryRepository.UpdateBloodInventory(updateBloodInventory);
        //    return Ok();
        //}

        [HttpGet]
        public ActionResult<IEnumerable<GetBloodInventoryDto>> GetBloodInventory() 
        {
            var bloodInventories = _bloodInventoryRepository.GetBloodInventories();
            return Ok(bloodInventories);
        }

    }
}

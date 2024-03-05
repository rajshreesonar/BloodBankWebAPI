using AutoMapper;
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
        private readonly IMapper _mapper;

        public BloodInventoryController(IBloodInventoryRepository bloodInventoryRepository, IMapper mapper)
        {
            _bloodInventoryRepository = bloodInventoryRepository;
            _mapper = mapper;
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
        //  ActionResult<IEnumerable<GetBloodInventoryDto>>
        [HttpGet]
        public async Task<IActionResult> GetBloodInventory() 
        {
            var bloodInventories = await _bloodInventoryRepository.GetBloodInventories();
            var map = _mapper.Map<IEnumerable<GetBloodInventoryDto>>(bloodInventories);
            return Ok(map);
        }

    }
}

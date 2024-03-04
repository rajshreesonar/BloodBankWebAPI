using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private readonly IRecipientRepository _recipientRepository;
        private readonly IBloodInventoryRepository _inventoryRepository;
        private readonly ITransfusionRepository _transfusionRepository;
        private readonly IMapper _mapper;

        public RecipientController(IRecipientRepository recipientRepository, IBloodInventoryRepository bloodInventoryRepository, ITransfusionRepository transfusionRepository, IMapper mapper)
        {
            _recipientRepository = recipientRepository;
            _inventoryRepository = bloodInventoryRepository;
            _transfusionRepository = transfusionRepository;
            _mapper = mapper;
        }
        [HttpPost("AddRecipient"),Authorize]
        public async Task<IActionResult> AddRecipient(AddRecipientDto addRecipient)
        {
            int id = await _recipientRepository.AddRecipient(addRecipient);

           // var recipient = _recipientRepository.GetAllRecipients().LastOrDefault();
            AddTransfusionDto addTransfusionDto = new AddTransfusionDto();

            addTransfusionDto.RecipientId = id;
            addTransfusionDto.TransfusionDate = DateTime.Now;
            addTransfusionDto.Quantity = addRecipient.Quantity;
            addTransfusionDto.HospitalId = addRecipient.HospitalId;

            GetBloodInventoryDto inventory = _inventoryRepository.GetBloodInventories()
                .Where(i => i.BloodType.ToLower() == addRecipient.BloodType.ToLower() && i.Quantity >= addRecipient.Quantity)
                .FirstOrDefault();

            if (inventory == null) return NotFound(); 
            addTransfusionDto.BloodInventoryId = inventory.Id;

            await _transfusionRepository.AddTransfusion(addTransfusionDto);
            return Ok(id);
        }
        [HttpPut("UpdateRecipient"),Authorize]
        public IActionResult UpdateRecipient(UpdateRecipientDto updateRecipient)
        {
            var map = _mapper.Map<Recipient>(updateRecipient);
            _recipientRepository.UpdateRecipient(map);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipient()
        {
            var recipients = await _recipientRepository.GetAllRecipients();
            var map = _mapper.Map<GetRecipientDto>(recipients);

            return Ok(map);
        }

        //[HttpGet("srearch")]
        //public ActionResult<IEnumerable<GetRecipientDto>> SearchDonor(string search)
        //{
        //    IEnumerable<GetRecipientDto> recipients = _recipientRepository.GetAllRecipients();
        //    recipients = recipients.Where(i => i.FirstName.ToLower().Contains(search.ToLower()) ||
        //                          i.LastName.ToLower().Contains(search.ToLower()) ||
        //                          i.Age.ToString().Contains(search) ||
        //                          i.Gender.ToLower().Contains(search.ToLower()) ||
        //                          i.BloodType.ToLower().Contains(search.ToLower()));
                                                                  
        //    if (!recipients.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(recipients);
        //}
    }
}

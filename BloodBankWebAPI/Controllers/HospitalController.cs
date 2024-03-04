using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        [HttpPost("AddHospital"),Authorize]
        public async Task<IActionResult> AddHospital(AddHospitalDto addHospital)
        {
            return Ok(await _hospitalRepository.AddHospital(addHospital));
        }

        [HttpPut("UpdateHospital"),Authorize]
        public async Task<IActionResult> UpdateHospital(UpdateHospitalDto updateHospital)
        {
            return Ok(await _hospitalRepository.UpdateHospital(updateHospital));
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals= await _hospitalRepository.GetHospitals();
            return Ok(hospitals);
        }
    }
}

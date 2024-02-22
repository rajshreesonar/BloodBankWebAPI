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
        public IActionResult AddHospital(AddHospitalDto addHospital)
        {
            _hospitalRepository.AddHospital(addHospital);
            return Ok();
        }

        [HttpPut("UpdateHospital"),Authorize]
        public IActionResult UpdateHospital(UpdateHospitalDto updateHospital)
        {
            _hospitalRepository.UpdateHospital(updateHospital);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetHospitalDto>> GetHospitals()
        {
            var hospitals=_hospitalRepository.GetHospitals();
            return Ok(hospitals);
        }
    }
}

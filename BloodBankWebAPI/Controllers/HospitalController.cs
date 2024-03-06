using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
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
        private readonly IMapper _mapper;

        public HospitalController(IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        [HttpPost("AddHospital")]
        public async Task<IActionResult> AddHospital(AddHospitalDto addHospital)
        {
            var map = _mapper.Map<Hospital>(addHospital);
            return Ok(await _hospitalRepository.AddHospital(map));
        }

        [HttpPut("UpdateHospital")]
        public async Task<IActionResult> UpdateHospital(UpdateHospitalDto updateHospital)
        {
            try
            {
                var hospital = await _hospitalRepository.GetHospitalById(updateHospital.Id);
                if (hospital != null)
                {
                    hospital.UpdateHospital(updateHospital.Name, updateHospital.Contact);
                    await _hospitalRepository.UpdateHospital(hospital);
                }
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

            //var map = _mapper.Map<Hospital>(updateHospital);
            //return Ok(await _hospitalRepository.UpdateHospital(map));
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals= await _hospitalRepository.GetHospitals();
            var map = _mapper.Map<IEnumerable<GetHospitalDto>>(hospitals);
            return Ok(map);
        }

        [HttpGet("GetHospitalById")]
        public async Task<IActionResult> GetHospitalById(int id)
        {
            var hospital = await _hospitalRepository.GetHospitalById(id);

            if (hospital == null)
            {
                throw new NotFoundException("Id is not available");
                //return BadRequest("Id is not available");
            }
            var map = _mapper.Map<IEnumerable<GetHospitalDto>>(hospital);  
            return Ok(map);
        }
    }
}

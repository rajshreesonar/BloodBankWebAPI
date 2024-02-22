using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorRepository _donorRepository;

        public DonorController(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        [HttpPost("AddDonor"), Authorize]

        public IActionResult AddDonor(AddDonorDto addDonor)
        {
            //mapp addDonorDto to Donor
            _donorRepository.AddDonor(addDonor);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetDonorDto>> GetDonors()
        {
            var donors = _donorRepository.GetAllDonors();
            return Ok(donors);
        }

        [HttpPut("UpdateDonor"), Authorize]
        public IActionResult UpdateDonor(UpdateDonorDto updateDonor)
        {
            _donorRepository.UpdateDonor(updateDonor);
            return Ok();
        }

        [HttpGet("srearch")]
        public ActionResult<IEnumerable<GetDonorDto>> SearchDonor(string search)
        {
            IEnumerable<GetDonorDto> donors = _donorRepository.GetAllDonors();

            donors = donors.Where(i => i.FirstName.ToLower().Contains(search.ToLower()) ||
                                  i.LastName.ToLower().Contains(search.ToLower()) ||
                                  i.Age.ToString().Contains(search) ||
                                  i.Gender.ToLower().Contains(search.ToLower()) ||
                                  i.BloodType.ToLower().Contains(search.ToLower()) ||
                                  i.FirstName.ToLower().Contains(search.ToLower()) ||
                                  i.HealthStatus.ToLower().Contains(search.ToLower()));
            if (!donors.Any())
            {
                throw new NotFoundException("Record not found");

            }
            return Ok(donors);
        }

    }
}

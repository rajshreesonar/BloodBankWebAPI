using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationRepository _donationRepository;

        public DonationController(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<GetDonationDto>> GetDonations()
        {
            var donations = _donationRepository.GetDonations();
            return Ok(donations);
        }

       // [HttpGet]
        //public ActionResult GetDonationsPdf(int id) { }

        [HttpPost("AddDonation"),Authorize]
        public IActionResult AddDonations(AddDonationDto addDonation)
        {
            _donationRepository.AddDonation(addDonation);
            return Ok();
        }

        [HttpPut("UpdateDonation"),Authorize]
        public IActionResult UpdateDonations(UpdateDonationDto updateDonation) 
        { 
            _donationRepository.UpdateDonation(updateDonation);
            return Ok();
        }

        


    }

}

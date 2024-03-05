using AutoMapper;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminController(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

     //   ActionResult<IEnumerable<GetAdminDto>>
        [HttpGet]
        public async Task<IActionResult> GetAdmin() 
        {
            var admins = await _adminRepository.GetAdmin();
            var map = _mapper.Map<IEnumerable<GetAdminDto>>(admins);
            return Ok(map);
        }
    }
}

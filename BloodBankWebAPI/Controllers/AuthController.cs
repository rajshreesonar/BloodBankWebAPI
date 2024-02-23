using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
using Azure.Core;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly BloodBankContext _context;
        public AuthController(IConfiguration configuration, IAdminRepository adminRepository, IMapper mapper, BloodBankContext context)
        {
            _configuration = configuration;
            _adminRepository = adminRepository;
            _mapper= mapper;
            _context= context;
        }

        [HttpPost("Registration")]
        public IActionResult AddAdmin(AddAdminDto addAdminDto)
        {
            bool registerAdmin = _adminRepository.AleadyRegister(addAdminDto.userName);

            if (registerAdmin)
            {
                return BadRequest("user aleady registered");
            }
            else
            {
                CreatePasswordHash(addAdminDto.password, out byte[] passwordHash, out byte[] passwordSalt);

                Admin admin = _mapper.Map<Admin>(addAdminDto);
                admin.userName = addAdminDto.userName;
                admin.PasswordHash = passwordHash;
                admin.PasswordSalt = passwordSalt;
                _adminRepository.AddAdmin(admin);
                return Ok();
            }
           // return Ok(user);
        }

        [HttpPost("Login")]

        public async Task<ActionResult<string>> Login(AdminAuthenticationDto request)
        {
            IEnumerable<Admin> user = _adminRepository.Login(request.userName);
            if (!user.Any()) return NotFound("Username not found");
            foreach (var item in user)
            {
                if (VerifyPasswordHash(request.password, item.PasswordHash, item.PasswordSalt))
                {
                    string token = CreateToken(item);
                    return Ok(token);
                }
            }
            return BadRequest("User not Valid!!");
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(Admin user)
        {
            List<Claim> Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id+""),
                new Claim(ClaimTypes.Name, user.userName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}

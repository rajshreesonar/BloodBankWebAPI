﻿using System.Security.Claims;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Serilog.Context;

namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorRepository _donorRepository;
        private readonly ILogger<DonorController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BloodBankContext _context;


        public DonorController(IDonorRepository donorRepository, ILogger<DonorController> logger, IHttpContextAccessor contextAccessor, BloodBankContext context)
        {
            _donorRepository = donorRepository;
            _logger = logger;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        [HttpPost("AddDonor"), Authorize]

        public IActionResult AddDonor(AddDonorDto addDonor)
        { 
          //  LogContext.PushProperty("AdminName", _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));
         //   Serilog.Log.Information("Donor added");
            
            //mapp addDonorDto to Donor
            _donorRepository.AddDonor(addDonor);
            return Ok();
        }

        //[HttpGet("GenerateDonorCertificate")]
        //public byte[] GenerateCertificate(int id)
        //{
        //    Donor donor= _context.Donor.Where(i=>i.Id == id).FirstOrDefault();

        //    if (donor != null) 
        //    {
        //        var data = new PdfDocument();

        //        string htmlContent = "<div style = 'margin: 20px auto; max-width: 600px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >";
        //        htmlContent += "<div style = 'margin-bottom: 20px; text-align: center;'>";
        //        htmlContent += "<img src = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROnYPD5QO8ZJvPQt8ClnJNPXduCeX89dSOxA&usqp=CAU' alt = 'School Logo' style = 'max-width: 100px; margin-bottom: 10px;' >";
        //        htmlContent += "</div>";
        //    }





        //}

        [HttpGet("GetDonors")]
        public ActionResult<IEnumerable<GetDonorDto>> GetDonors()
        {
            _logger.LogInformation("seri log is working");
            var donors = _donorRepository.GetAllDonors();
            _logger.LogWarning("seri log is existing");
            return Ok(donors);
        }

        [HttpGet]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads\\", fileName);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }

        [HttpPut("UpdateDonor"), Authorize]
        public IActionResult UpdateDonor(UpdateDonorDto updateDonor)
        {
            _donorRepository.UpdateDonor(updateDonor);
            return Ok();
        }

        [HttpGet("srearch")]
        public ActionResult<IEnumerable<GetDonorDto>> SearchDonor(string? search)
        {
            try
            {
                IEnumerable<GetDonorDto> donors = _donorRepository.GetAllDonors();

                donors = donors.Where(i => i.FirstName.ToLower().Contains(search.ToLower()) ||
                                      i.LastName.ToLower().Contains(search.ToLower()) ||
                                      i.Dob.ToString().Contains(search) ||
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
            catch (Exception)
            {

                throw;
            }
        }

    }
}

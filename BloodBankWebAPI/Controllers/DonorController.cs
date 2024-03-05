using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Middlewares;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

using PdfSharpCore;

using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

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
        private readonly IMapper _mapper;
        public DonorController(IDonorRepository donorRepository, ILogger<DonorController> logger, IHttpContextAccessor contextAccessor, BloodBankContext context, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _logger = logger;
            _contextAccessor = contextAccessor;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("AddDonor")]
        public async Task<IActionResult> AddDonor(AddDonorDto addDonor)
        {
            //  LogContext.PushProperty("AdminName", _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));
            //   Serilog.Log.Information("Donor added");

            var map = _mapper.Map<Donor>(addDonor);
            if (addDonor.adharUpload is not null)
            {
                var directoryPath = Directory.GetCurrentDirectory() + "\\uploads";

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var filePath = Path.Combine(directoryPath, addDonor.adharUpload.FileName);

                using (var stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    addDonor.adharUpload.CopyToAsync(stream);
                }
                map.FilePath = filePath;
            }

            var age = DateTime.Now.Year - addDonor.Dob.Year;
            if ((int)age <= 18)
            {
                throw new BadRequestException("Age must be greater than 18");
            }
            
            return Ok(await _donorRepository.AddDonor(map));
        }

        [HttpGet("GenerateDonorCertificate")]
        public IActionResult GenerateCertificate(int id)
        {
            Donor donor = _context.Donor.Where(i => i.Id == id).FirstOrDefault();

            if (donor != null)
            {
                var data = new PdfDocument();

                string htmlContent = "<div style = 'margin: 20px auto; max-width: 600px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >";
                htmlContent += "<div style = 'margin-bottom: 20px; text-align: center;'>";
                htmlContent += "<img src = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaG00j90EO8AuLHCqx8mD9qMRNo1Bb5HwfxeMw3Fe3_JPkkkcdN26Fv0QlDhoBAfE_WrE&usqp=CAU' alt = 'Blood Logo' style = 'max-width: 150px; margin-bottom: 10px;' >";
                htmlContent += "</div>";
                htmlContent += "<p style='font-size:40px;'> sir/smt./Kum " + donor.FirstName + " " + donor.LastName + " has donated 200ml blood at the Blood Donation Drive,Organized on Date " + donor.LastDonationDate + " by the Rakt-Dan Mahadan Charitable trust </p>";
                //htmlContent += "<p> Name:"+donor.FirstName +" "+donor.LastName+"</p>";
                //htmlContent += "<p> Name:" + donor.BloodType + " " + "</p>";
                //htmlContent += "<p> Name:" + donor.LastDonationDate +"</p>";
                htmlContent += "</div>";

                PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);
                byte[]? response = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    data.Save(ms);
                    response = ms.ToArray();
                }
                string fileName = "DonationCertificate" + id + ".pdf";
                return File(response, "application/pdf", fileName);
            }
            return NotFound();


        }
        [HttpGet("GetDonors")]
        public async Task<IActionResult> GetDonors()
        {
            //_logger.LogInformation("seri log is working");
            var donors = await _donorRepository.GetAllDonors();
            var map = _mapper.Map<IEnumerable<GetDonorDto>>(donors);
            //_logger.LogWarning("seri log is existing");
            return Ok(map);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads\\", fileName);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }

        [HttpPut("UpdateDonor"), Authorize]
        public async Task<IActionResult> UpdateDonor(UpdateDonorDto updateDonor)
        {
            var map = _mapper.Map<Donor>(updateDonor);
            return Ok(await _donorRepository.UpdateDonor(map));
        }

        [HttpGet("srearch")]
        public ActionResult<IEnumerable<GetDonorDto>> SearchDonor(string? search)
        {
            try
            {
                IEnumerable<GetDonorDto> donors = (IEnumerable<GetDonorDto>)_donorRepository.GetAllDonors();

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

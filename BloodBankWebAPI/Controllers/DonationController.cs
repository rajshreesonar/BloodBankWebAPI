using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using TheArtOfDev.HtmlRenderer.PdfSharp;

using PdfSharpCore.Pdf;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationRepository _donationRepository;
        private readonly BloodBankContext _context;
        private readonly IMapper _mapper;

        public DonationController(IDonationRepository donationRepository, BloodBankContext context, IMapper mapper)
        {
            _donationRepository = donationRepository;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetDonations()
        {
            var donations = await _donationRepository.GetDonations();
            var map = _mapper.Map<IEnumerable<GetDonationDto>>(donations);
            return Ok(map);
        }

       // [HttpGet]
        //public ActionResult GetDonationsPdf(int id) { }

        [HttpPost("AddDonation")]
        public async Task<IActionResult> AddDonations(AddDonationDto addDonation)
        {
            var map = _mapper.Map<Donation>(addDonation);
            return Ok(await _donationRepository.AddDonation(map));
        }

        [HttpPut("UpdateDonation"),Authorize]
        public IActionResult UpdateDonations(UpdateDonationDto updateDonation) 
        {
            var map = _mapper.Map<Donation>(updateDonation);
            _donationRepository.UpdateDonation(map);
            return Ok();
        }

        [HttpGet("GetDonationPdf")]
        public IActionResult GetDonationPdf()
        {
         //   _donationRepository.GetDonationPdf();

            IEnumerable<Donation> donations = _context.Donation.Include(i => i.Donor).ToList();

            var data = new PdfDocument();

            string htmlContent = "<div style = 'margin: 20px auto; max-width: 600px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >\r\n    " +
                "<div>\r\n<div style = 'text-align: center;'>\r\n<img src = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaG00j90EO8AuLHCqx8mD9qMRNo1Bb5HwfxeMw3Fe3_JPkkkcdN26Fv0QlDhoBAfE_WrE&usqp=CAU' height='190px' width='200px' >\r\n</div>" +
                "<div style = 'text-align: center; margin-bottom: 20px;'>\r\n<h1 style='color: #094549;'> Donations Report </h1>\r\n</div>\r\n<table style = 'width: 100%; border-collapse: collapse;'>\r\n<tbody>\r\n<tr style = 'color: #2398a0;font-size: 16px' >\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > DonationID </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Donor Name </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Donation Quantity </td>\r\n" +
                "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > BloodType </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' >  Donation DateTime </td></tr>";

            for (int i = 0; i < donations.Count(); i++)
            {
                htmlContent += "<tr>\r\n";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).ID + "</td>\r\n";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).Donor.FirstName + " " + donations.ElementAt(i).Donor.LastName + " </td>\r\n";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).Quantity_ML+ " </td>\r\n";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).BloodType+" </td>\r\n";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).DonationDate + " </td>\r\n</tr>";
            }
            htmlContent += "</tbody></table></div>";

            PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                data.Save(ms);
                response = ms.ToArray();
            }
           // return Ok();
            string fileName = "DonationCertificate" + ".pdf";
            return File(response, "application/pdf", fileName);
        }


    }

}

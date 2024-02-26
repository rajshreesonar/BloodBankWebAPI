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
namespace BloodBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationRepository _donationRepository;
        private readonly BloodBankContext _context;

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

        [HttpGet("GetDonationPdf")]
        public IActionResult GetDonationPdf()
        {
         //   _donationRepository.GetDonationPdf();

            IEnumerable<Donation> donations = _context.Donation.Include(i => i.Donor).ToList();

            var data = new PdfDocument();

            string htmlContent = "<div style = 'margin: 20px auto; max-width: 600px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >\r\n    " +
                "<div>\r\n<div style = 'text-align: center;'>\r\n<img src = 'https://media.istockphoto.com/id/1624291952/vector/medical-health-logo-design-illustration.jpg?s=612x612&w=0&k=20&c=RdOq1SRcWwS_12_c5Zg2_QOUz1GD-YwGvfRodtOPN5w=' height='190px' width='200px' >\r\n</div>\r\n" +
                "<p style = 'margin: 0;color: #52bb07;font-size: 20px;margin-bottom: 6px;' >Samved Hospital</p>\r\n" +
                "<p style = 'margin: 0;' > 3rd floor, cross road complex,</p>\r\n<p style = 'margin: 0;margin-bottom: 6px;' >below bansri hospital, Amroli, Surat</p>\r\n" +
                "<p style = 'margin: 0;margin-bottom: 6px;' > Phone: +91 98758 65784 </p>\r\n<p style = 'margin: 0;' > Gujarat </p>\r\n</div>\r\n" +
                "<div style = 'text-align: center; margin-bottom: 20px;'>\r\n<h1 style='color: #094549;'> Appointment Report </h1>\r\n</div>\r\n<table style = 'width: 100%; border-collapse: collapse;'>\r\n<tbody>\r\n<tr style = 'color: #2398a0;font-size: 16px' >\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Patient </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Appoint Doctor </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Doctor Speciality </td>\r\n" +
                "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Disease </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Appoint DateTime </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Status </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Appoint DateTime </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > IsDeleted </td>\r\n</tr>\r\n";

            for (int i = 0; i < donations.Count(); i++)
            {
                htmlContent += "<tr>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).Donor.FirstName + " " + donations.ElementAt(i).Donor.LastName + " </td>\r\n";
                htmlContent += "<tr>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).Donor.FirstName + " " + donations.ElementAt(i).Donor.LastName + " </td>\r\n";
                htmlContent += "<tr>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).Donor.FirstName + " " + donations.ElementAt(i).Donor.LastName + " </td>\r\n";
            }
            htmlContent += "</tbody></table></div>";

            PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                data.Save(ms);
                response = ms.ToArray();
            }
            string fileName = "DonationCertificate" + ".pdf";
            return File(response, "application/pdf", fileName);
        }


    }

}

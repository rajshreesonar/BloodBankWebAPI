using AutoMapper;
using BloodBankWebAPI.Contexts;
using BloodBankWebAPI.Dtos.AddDtos;
using BloodBankWebAPI.Dtos.GetDtos;
using BloodBankWebAPI.Dtos.UpdateDtos;
using BloodBankWebAPI.Models;
using BloodBankWebAPI.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Pdf;

namespace BloodBankWebAPI.Repositories
{
    public class DonationRepository :IDonationRepository
    {
        private readonly BloodBankContext _context;
        private readonly IMapper _mapper;
        private readonly IBloodInventoryRepository _inventoryRepository;
        public DonationRepository(BloodBankContext context,IMapper mapper, IBloodInventoryRepository bloodInventory) 
        { 
            _context = context;
            _mapper = mapper;
            _inventoryRepository = bloodInventory;
        }

        public async Task<int> AddDonation(AddDonationDto addDonation)
        {
            var map= _mapper.Map<Donation>(addDonation);
            await _context.Donation.AddAsync(map);
            _context.SaveChangesAsync();

            var donation = _context.Donation.OrderBy(item => item.ID).LastOrDefault();
    
            AddBloodInventoryDto addBloodInventory = new AddBloodInventoryDto();

            addBloodInventory.DonationId = donation.ID;
            addBloodInventory.Quantity = donation.Quantity_ML;
            addBloodInventory.BloodType = donation.BloodType;
            addBloodInventory.ExpiryDate = donation.DonationDate.AddDays(5);

            return await _inventoryRepository.AddBloodInventory(addBloodInventory);



        }
        public void UpdateDonation(UpdateDonationDto updateDonation)
        {
             var map = _mapper.Map<Donation>(updateDonation);
            _context.Donation.Update(map);
            _context.SaveChanges();
        }
        public async Task<IEnumerable<GetDonationDto>> GetDonations()   
        {
            var donations= await _context.Donation.Include(i=>i.Donor).ToListAsync();
            var map = _mapper.Map<IEnumerable<GetDonationDto>>(donations);
            return map;
        }

        //public byte[] GetDonationPdf()
        //{
            //IEnumerable<Donation> donations = _context.Donation.Include(i => i.Donor).ToList();

            //var data = PdfDocument();

            //string htmlContent = "<div style = 'margin: 20px auto; max-width: 600px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >\r\n    " +
            //    "<div>\r\n<div style = 'text-align: center;'>\r\n<img src = 'https://media.istockphoto.com/id/1624291952/vector/medical-health-logo-design-illustration.jpg?s=612x612&w=0&k=20&c=RdOq1SRcWwS_12_c5Zg2_QOUz1GD-YwGvfRodtOPN5w=' height='190px' width='200px' >\r\n</div>\r\n" +
            //    "<p style = 'margin: 0;color: #52bb07;font-size: 20px;margin-bottom: 6px;' >Samved Hospital</p>\r\n" +
            //    "<p style = 'margin: 0;' > 3rd floor, cross road complex,</p>\r\n<p style = 'margin: 0;margin-bottom: 6px;' >below bansri hospital, Amroli, Surat</p>\r\n" +
            //    "<p style = 'margin: 0;margin-bottom: 6px;' > Phone: +91 98758 65784 </p>\r\n<p style = 'margin: 0;' > Gujarat </p>\r\n</div>\r\n" +
            //    "<div style = 'text-align: center; margin-bottom: 20px;'>\r\n<h1 style='color: #094549;'> Appointment Report </h1>\r\n</div>\r\n<table style = 'width: 100%; border-collapse: collapse;'>\r\n<tbody>\r\n<tr style = 'color: #2398a0;font-size: 16px' >\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Patient </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Appoint Doctor </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Doctor Speciality </td>\r\n" +
            //    "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Disease </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Appoint DateTime </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Status </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Appoint DateTime </td>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > IsDeleted </td>\r\n</tr>\r\n";

            //for (int i = 0; i < donations.Count(); i++)
            //{
            //    htmlContent += "<tr>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).Donor.FirstName+" " + donations.ElementAt(i).Donor.LastName + " </td>\r\n";
            //    htmlContent += "<tr>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).Donor.FirstName + " " + donations.ElementAt(i).Donor.LastName + " </td>\r\n";
            //    htmlContent += "<tr>\r\n<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > " + donations.ElementAt(i).Donor.FirstName + " " + donations.ElementAt(i).Donor.LastName + " </td>\r\n";
            //}
            //htmlContent += "</tbody></table></div>";

            //PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);
            //byte[]? response = null;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    data.Save(ms);
            //    response = ms.ToArray();
            //}
            //return response;
        //}
    }
}               

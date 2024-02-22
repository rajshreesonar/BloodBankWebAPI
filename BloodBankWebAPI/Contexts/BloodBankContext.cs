using BloodBankWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodBankWebAPI.Contexts
{
    public class BloodBankContext : DbContext
    {
        public BloodBankContext(DbContextOptions<BloodBankContext> options):base(options) { }

        public DbSet<Donor> Donor { get; set; }
        public DbSet<Recipient> Recipient { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<Transfusion> Transfusion { get; set; }
        public DbSet<BloodInventory> BloodInventorie { get; set; }
        public DbSet<Admin> Admin { get; set; }

    }
}

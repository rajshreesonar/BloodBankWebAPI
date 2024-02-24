using BloodBankWebAPI.Middlewares;
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

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var entries = ChangeTracker
        //        .Entries()
        //        .Where(e => e.Entity is DateClass && (
        //                e.State == EntityState.Added
        //                || e.State == EntityState.Modified));

        //    foreach (var entityEntry in entries)
        //    {
        //        ((DateClass)entityEntry.Entity).UpdatedDate = DateTime.Now;

        //        if (entityEntry.State == EntityState.Added)
        //        {
        //            ((DateClass)entityEntry.Entity).CreatedDate = DateTime.Now;
        //        }

        //        CustomLog.CreateLog(entityEntry);
        //    }
        //    return await base.SaveChangesAsync();
        //}
    }
}

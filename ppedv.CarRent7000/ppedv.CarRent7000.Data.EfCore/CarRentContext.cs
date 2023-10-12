using Microsoft.EntityFrameworkCore;
using ppedv.CarRent7000.Model.DomainModel;

namespace ppedv.CarRent7000.Data.EfCore
{
    public class CarRentContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var constring = "Server=(localdb)\\mssqllocaldb;Database=CarRent7000_dev;Trusted_Connection=true";
            optionsBuilder.UseSqlServer(constring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rent>().HasOne(x => x.Biller).WithMany(x => x.RentsAsBiller);
            modelBuilder.Entity<Rent>().HasOne(x => x.Driver).WithMany(x => x.RentsAsDriver);
        }
    }
}

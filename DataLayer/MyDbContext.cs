using DataLayer.Configurations;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ContactConfiguration());

        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                ContactId = Guid.NewGuid(), 
                Name = "Luke", 
                MobilePhone = "+375291234569", 
                BirthDate = new DateTime(1982, 2, 3), 
                JobTitle = "Programmer"
            },
            new Contact
            {
                ContactId = Guid.NewGuid(), 
                Name = "Madeleine", 
                MobilePhone = "+375331238669", 
                BirthDate = new DateTime(1993, 5, 19), 
                JobTitle = "Accountant"
            },
            new Contact
            {
                ContactId = Guid.NewGuid(), 
                Name = "Ilya", 
                MobilePhone = "+375298732839", 
                BirthDate = new DateTime(2002, 5, 8), 
                JobTitle = "Programmer"
            },
            new Contact
            {
                ContactId = Guid.NewGuid(), 
                Name = "Oswald", 
                MobilePhone = "+375441254889", 
                BirthDate = new DateTime(2000, 7, 25), 
                JobTitle = "Loader"
            });
    }
}
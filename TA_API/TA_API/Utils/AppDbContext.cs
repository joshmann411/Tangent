using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TA_API.Models;
using TA_API.Utils;

namespace TA_API.Utils
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Skill> Skills { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedDatabase(this, builder);
        }

        private static void SeedDatabase(AppDbContext dbContext, ModelBuilder mBuilder)
        {
            Helper _helper =  new Helper();



            mBuilder.Entity<Employee>().HasData(
              new Employee
              {
                  Id = _helper.GenerateValidIdWithoutDbChecks("John", "Doe"),
                  FirstName = "John",
                  LastName = "Doe",
                  ContactNumber = "0762344321",
                  Email = "johndoe@gmail.com",
                  DateOfBirth = new DateTime(1996, 06, 22),
              },
              new Employee
              {
                  Id = _helper.GenerateValidIdWithoutDbChecks("Bandile", "Samson"),
                  FirstName = "Bandile",
                  LastName = "Samson",
                  Email = "bayee@gmail.com",
                  ContactNumber = "0962394321",
                  DateOfBirth = new DateTime(1990, 03, 02)
              });


            #region Not_Needed_For_Now

            //mBuilder.Entity<Address>().HasData(
            //    new Address
            //    {
            //        Id = 1,
            //        Street_number = "318",
            //        Street = "5th Avenue",
            //        Building_name = "",
            //        Unit_number = "",
            //        Address_instruction = "",
            //        Suburb = "Capital Park",
            //        City = "Pretoria",
            //        State = "Gauteng", //province in the front end
            //        Country = "South Africa", //this should be default for now
            //        Postal_code = "0084",
            //        Longitude = "",
            //        Latitude = "",
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = null
            //    },
            //    new Address
            //    {
            //        Id = 2,
            //        Street_number = "177",
            //        Street = "Venter Street",
            //        Building_name = "",
            //        Unit_number = "",
            //        Address_instruction = "",
            //        Suburb = "Capital Park",
            //        City = "Pretoria",
            //        State = "Gauteng", //province in the front end
            //        Country = "South Africa", //this should be default for now
            //        Postal_code = "0084",
            //        Longitude = "",
            //        Latitude = "",
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = null,
            //    });



            //builder.Entity<Skill>().HasData(
            //    new Skill
            //    {
            //        Id = 1,
            //        SeniorityRating = Rating.Beginner,
            //        SkillName = "Java",
            //        YearsOfExperience = 10,
            //        EmployeeId = 1
            //    },

            //    new Skill
            //    {
            //        Id = 2,
            //        SeniorityRating = Rating.Expert,
            //        SkillName = "PowerBI",
            //        EmployeeId = 2
            //    });

            #endregion
        }
    }
}
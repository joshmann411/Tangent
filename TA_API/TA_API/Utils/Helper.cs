using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TA_API.Models;

namespace TA_API.Utils
{
    public class Helper
    {
        private readonly AppDbContext _dbContext;

        public Helper()
        {
        }

        public Helper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetUppercaseInitials(string firstName, string lastName)
        {
            char firstInitial = char.ToUpper(firstName[0]);
            char lastInitial = char.ToUpper(lastName[0]);

            return $"{firstInitial}{lastInitial}";
        }


        //TEST
        public int GenerateUniqueNumbersWithDbChecks()
        {
            List<int> uniqueNumbers = new List<int>();
            Random random = new Random();


            while (uniqueNumbers.Count < 4)
            {
                int randomNumber = random.Next(1, 9);

                uniqueNumbers.Add(randomNumber);
            }

            // Check if the generated number already exists in the database in the subset of the IDs
            bool numberExists = _dbContext.Set<Employee>().Any(e => Convert.ToInt32(e.Id.Substring(2)) == int.Parse(string.Join("", uniqueNumbers)));

            //in case it does not exist
            if (!numberExists)
            {
                //return uniqueNumbers;
                return int.Parse(string.Join("", uniqueNumbers));
            }
            else
            {
                //regenerate
                GenerateUniqueNumbersWithDbChecks();
            }

            return 0;
        }

        
        //Generate ID for employee (GetUppercaseInitials + GenerateUniqueNumbers)
        public string GenerateValidId(string firstname, string lastname)
        {
            //
            string upperCaseInitials = GetUppercaseInitials(firstname, lastname);

            //
            int random4 = GenerateUniqueNumbersWithDbChecks();

            if (random4 != 0 && random4 > 0)
            {
                return $"{upperCaseInitials}{random4.ToString()}";
            }

            return "error";
        }




        //======================================================================

        //For seeding test
        public int GenerateUniqueNumbersWithoutDbChecks()
        {
            List<int> uniqueNumbers = new List<int>();
            Random random = new Random();


            while (uniqueNumbers.Count < 4)
            {
                int randomNumber = random.Next(1, 9);

                uniqueNumbers.Add(randomNumber);
            }

            //return uniqueNumbers;
            return int.Parse(string.Join("", uniqueNumbers));

        }


        //For seeding test
        public string GenerateValidIdWithoutDbChecks(string firstname, string lastname)
        {
            //
            string upperCaseInitials = GetUppercaseInitials(firstname, lastname);

            //
            int random4 = GenerateUniqueNumbersWithoutDbChecks();

            if (random4 != 0 && random4 > 0)
            {
                return $"{upperCaseInitials}{random4.ToString()}";
            }

            return "error";
        }
    }
}

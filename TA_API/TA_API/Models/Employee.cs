using System.ComponentModel.DataAnnotations;

namespace TA_API.Models
{
    public class Employee
    {
        [Required]
        public string Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        public string ContactNumber { get; set; }
        
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}

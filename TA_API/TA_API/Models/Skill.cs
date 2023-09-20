using System.ComponentModel.DataAnnotations;

namespace TA_API.Models
{
    public class Skill
    {
        public int Id { get; set; }
        
        [Required]
        public string? EmployeeId { get; set; }
        public int Experience { get; set; }
        public string? SeniorityRating { get; set; }
    }
}

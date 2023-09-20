using System.ComponentModel.DataAnnotations;

namespace TA_API.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string SkillName { get; set; }   
        [Required]
        public string EmployeeId { get; set; }
        public int YearsOfExperience { get; set; }
        public Rating SeniorityRating { get; set; }
    }

    public enum Rating
    {
        Beginner = 0,
        Intermediate = 1,
        Expert = 2
    }
}

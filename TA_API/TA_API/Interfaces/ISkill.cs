using TA_API.Models;

namespace TA_API.Interfaces
{
    public interface ISkill
    {
        Task<IEnumerable<Skill>> GetAllSkills();
        Task<Skill> GetSkill(int id);
        Task<String> AddSkill(Skill skill);
        Task<String> UpdateSkill(Skill skillChanges);
        Task<String> DeleteSkill(int Id);
    }
}

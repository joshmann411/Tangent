using Microsoft.AspNetCore.Mvc;
using TA_API.Models;

namespace TA_API.Interfaces
{
    public interface ISkill
    {
        Task<JsonResult> GetAllSkills();
        Task<JsonResult> GetSkill(int id);
        Task<string> AddSkill(Skill skill);
        Task<string> UpdateSkill(Skill skillChanges);
        Task<string> DeleteSkill(int Id);
    }
}

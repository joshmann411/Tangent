using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TA_API.Interfaces;
using TA_API.Models;
using TA_API.Utils;

namespace TA_API.Repository
{
    public class SqlSkillRepository : ISkill
    {
        private readonly ILogger<SqlSkillRepository> _logger;
        private readonly AppDbContext _context;
        public SqlSkillRepository(
            AppDbContext context,
            ILogger<SqlSkillRepository> logger)
        {
            _context = context;
            _logger = logger;
        }



        public async Task<string> AddSkill(Skill skill)
        {
            _logger.LogInformation($"Repo Level Logging: Adding a new skill for employee with ID: ${skill.EmployeeId}.");
            await _context.AddAsync(skill);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Repo Level Logging: Skill Added Successfully =====>");
            return "Skill added successfully";
        }

        public async Task<string> DeleteSkill(int Id)
        {
            if(Id > 0)
            {
                _logger.LogInformation($"Repo Level Logging: Removing skill for a valid ID: ${Id}.");
                
                Skill skill = await _context.Skills.FindAsync(Id);

                if (skill != null)
                {
                    _context.Remove(skill);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Repo Level Logging: Skill with ID ${Id} removed successfully ===>");

                    return "Skill removed successfully";
                }

                return "error 1: Skill not found";
            }

            return "error 2: invalid ID";
        }

        public async Task<JsonResult> GetAllSkills()
        {
            _logger.LogInformation($"Repo Level Logging: Getting all skills.");

            var result = await _context.Skills.ToListAsync();

            _logger.LogInformation($"Repo Level Logging: {result.Count()} skills retrieved.");

            return new JsonResult(result);
        }

        public async Task<JsonResult> GetSkill(int id)
        {
            _logger.LogInformation($"Repo Level Logging: Getting skill with ID: ${id}");
            var result = await _context.Skills.FindAsync(id);
            _logger.LogInformation($"Repo Level Logging: Skill with ID: ${id} retrieved successfully.");
            return new JsonResult(result);
        }

        public async Task<JsonResult> GetSkillsOfEmployee(string employeeId)
        {
            if(!string.IsNullOrEmpty(employeeId))
            {
                _logger.LogInformation($"Repo Level Logging: Getting skills of employee with ID: ${employeeId}");
                var allSkills = await _context.Skills.ToListAsync();
                var result = allSkills.Where(a => a.EmployeeId.Equals(employeeId)).ToList();
                _logger.LogInformation($"Repo Level Logging: Skills of employee with ID: ${employeeId} retrieved successfully.");
                return new JsonResult(result);
            }

            return new JsonResult("invalid employee id");
        }

        public async Task<string> UpdateSkill(Skill skillChanges)
        {
            _logger.LogInformation($"Repo Level Logging: Updating incoming skill of ID: ${skillChanges.Id} with values ${new JsonResult(skillChanges)}"); 

            var tm = _context.Skills.Attach(skillChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            await _context.DisposeAsync();

            _logger.LogInformation($"Repo Level Logging: Updated successfulle");

            return "Updated Successfully !";
        }
    }

}

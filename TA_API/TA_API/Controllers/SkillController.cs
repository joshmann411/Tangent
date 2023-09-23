using Microsoft.AspNetCore.Mvc;
using System.Net;
using TA_API.Interfaces;
using TA_API.Models;

namespace TA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkill _skills;
        private readonly ILogger<SkillController> _logger;

        public SkillController(
            ISkill skillRepository,
            ILogger<SkillController> logger)
        {
            _logger = logger;
            _skills = skillRepository;
        }

        [HttpGet]
        [Route("GetAllSkills")]
        public async Task<JsonResult> GetAllSkills()
        {
            try
            {
                _logger.LogInformation("==> Retrieving list of known skills");

                var allSkills = await _skills.GetAllSkills();

                _logger.LogInformation("<== skills list retrieved");

                return allSkills;
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError("XXX Error while retrieving skills list. Exception {0}" + ex.Message.ToString());

                return new JsonResult("Error retrieving skills list");
            }
        }



        [HttpGet]
        [Route("GetSkillById/{id}")]
        public async Task<JsonResult> GetSkillById(int id)
        {
            try
            {
                _logger.LogInformation("==> Retrieving skill with ID: {0}", id.ToString());

                var skill = await _skills.GetSkill(id);

                _logger.LogInformation("<== skill with ID: {0} retrieved", id.ToString());

                return skill;
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError("XXX Error while retrieving skill with ID: {0} | Exception {1}", id.ToString(), ex.Message.ToString());

                //  
                return new JsonResult($"Error retrieving skill with ID {id}");
            }
        }


        [HttpGet]
        [Route("GetSkillsOfEmployee/{employeeId}")]
        public async Task<JsonResult> GetSkillsOfEmployee(string employeeId)
        {
            try
            {
                _logger.LogInformation($"==> Retrieving skills of employee with ID: {employeeId}");

                var skill = await _skills.GetSkillsOfEmployee(employeeId);

                _logger.LogInformation($"<== skill with ID: {employeeId} retrieved");

                return skill;
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError($"XXX Error while retrieving skills of employee with ID: {employeeId} | Exception {ex.Message.ToString()}");

                //  
                return new JsonResult($"Error retrieving skill with ID {employeeId}");
            }
        }

        [HttpPost]
        [Route("AddSkill")]
        public async Task<IActionResult> AddSkill([FromBody] Skill skill)
        {
            try
            {
                _logger.LogInformation($"CL: Add new skill to employee with ID: ${skill.EmployeeId}");

                var result = await _skills.AddSkill(skill);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CL: Error occurred while adding new skill. Exception: {ex.Message}");

                return new JsonResult("Error occurred");
            }
        }

        [HttpPost]
        [Route("AddMultipleSkill")]
        public async Task<IActionResult> AddMultipleSkill(Skill[] skills)
        {
            try
            {
                _logger.LogInformation($"CL: Add multiple skills to employee with ID: ${skills[0].EmployeeId}");

                var result = await _skills.AddMultipleSkill(skills);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CL: Error occurred while adding multiple skills. Exception: {ex.Message}");

                return new JsonResult("Error occurred");
            }
        }



        [HttpPut]
        [Route("UpdateSkill")]
        public async Task<string> UpdateSkill([FromBody] Skill skillChanges)
        {
            try
            {
                _logger.LogInformation($"Updating skill changes. Changes {new JsonResult(skillChanges)}: ");

                string response = await _skills.UpdateSkill(skillChanges);

                _logger.LogInformation("Updated Successfully");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while trying to update skill changes. Error Details: {0}", ex.Message.ToString());

                return "Error occurred while updating skill";
            }
        }



        [HttpDelete]
        [Route("DeleteSkill/{skillId}")]
        public async Task<string> DeleteSkill(int skillId)
        {
            try
            {
                _logger.LogInformation($"Deleting skill with ID: {skillId}");

                string response = await _skills.DeleteSkill(skillId);

                _logger.LogInformation("Deleted Successfully !");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete skill of ID: {skillId}. Exception: {ex.Message.ToString()}");

                return $"Error while deleting skill of ID: {skillId}";
            }
        }




    }
}

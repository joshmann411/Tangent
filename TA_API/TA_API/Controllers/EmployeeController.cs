using Microsoft.AspNetCore.Mvc;
using TA_API.Interfaces;
using TA_API.Models;

namespace TA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employees;
        private readonly ILogger<AddressController> _logger;

        public EmployeeController(
            IEmployee employeeRepository,
            ILogger<AddressController> logger)
        {
            _logger = logger;
            _employees = employeeRepository;
        }

        //Task<string> AddEmployee(Employee employee);
        //Task<string> UpdateEmployee(Employee employeeChanges);
        //Task<string> DeleteEmployeeWithId(string Id);

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<JsonResult> GetAllEmployees()
        {
            try
            {
                _logger.LogInformation("==> Retrieving list of known employees");

                var employees = await _employees.GetAllEmployees();

                _logger.LogInformation("<== employee list retrieved");

                return new JsonResult(employees.Value);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError("XXX Error while retrieving employee list. Exception {0}" + ex.Message.ToString());

                return new JsonResult("Error retrieving employee list");
            }
        }



        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<JsonResult> GetEmployeeById([FromRoute]string id)
        {
            try
            {
                _logger.LogInformation($"==> Retrieving employee with ID: {id}");

                var employee = await _employees.GetEmployeeById(id);

                _logger.LogInformation("<== Employee with ID: {0} retrieved", id);

                return employee;
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError("XXX Error while retrieving employee with ID: {0} | Exception {1}", id, ex.Message.ToString());

                //  
                return new JsonResult($"Error retrieving employee with ID {id}");
            }
        }


        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            try
            {
                _logger.LogInformation($"CL: Adding new employee");

                var result = await _employees.AddEmployee(employee);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CL: Error occurred while adding new employee. Exception: {ex.Message}");

                return new JsonResult("Error occurred while adding new employee");
            }
        }


        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<string> UpdateEmployee([FromBody] Employee employeeChanges)
        {
            try
            {
                _logger.LogInformation($"Updating employee changes. Changes {new JsonResult(employeeChanges)}: ");

                string response = await _employees.UpdateEmployee(employeeChanges);

                _logger.LogInformation("Updated Successfully");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while trying to update employee changes. Error Details: {0}", ex.Message.ToString());

                return "Error occurred while updating employee";
            }
        }



        [HttpDelete]
        [Route("DeleteEmployee/{employeeId}")]
        public async Task<string> DeleteEmployee(string employeeId)
        {
            try
            {
                _logger.LogInformation($"Deleting employee with ID: {employeeId}");

                string response = await _employees.DeleteEmployeeWithId(employeeId);

                _logger.LogInformation("Deleted Successfully !");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete employee of ID: {employeeId}. Exception: {ex.Message.ToString()}");

                return $"Error while deleting employee of ID: {employeeId}";
            }
        }
    }
}

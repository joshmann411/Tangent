using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TA_API.Interfaces;
using TA_API.Models;
using TA_API.Utils;

namespace TA_API.Repository
{
    public class SqlEmployeeRepository : IEmployee
    {
        private readonly ILogger<SqlEmployeeRepository> _logger;
        private readonly AppDbContext _context;
        public SqlEmployeeRepository(
            AppDbContext context,
            ILogger<SqlEmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> AddEmployee(Employee employee)
        {
            if (employee != null)
            {
               //ensure that the ID is generated (as microsoft won't generate it for you)
                if (employee.Id == null)
                {
                    Helper helper = new Helper(_context);
                    employee.Id = helper.GenerateValidId(employee.FirstName, employee.LastName);
                }

                _logger.LogInformation($"Repo Level Logging: Adding a new employee");
                await _context.AddAsync(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Repo Level Logging: Employee Added Successfully =====>");
                return "Employee added successfully";
            }
            return "error : invalid employee";
        }

        public async Task<string> DeleteEmployeeWithId(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                _logger.LogInformation($"Repo Level Logging: Removing employee with ID: ${Id}.");

                Employee emp = await _context.Employees.FindAsync(Id);

                if (emp != null)
                {
                    _context.Remove(emp);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Repo Level Logging: Employee with ID ${Id} removed successfully ===>");

                    return "Employee removed successfully";
                }

                return "error 1: Employee not found";
            }

            return "error 2: invalid ID";
        }

        public async Task<JsonResult> GetAllEmployees()
        {
            _logger.LogInformation($"Repo Level Logging: Getting all employees.");

            var result = await _context.Employees.ToListAsync();

            _logger.LogInformation($"Repo Level Logging: {result.Count()} employees retrieved.");

            return new JsonResult(result);
        }

        public async Task<JsonResult> GetEmployeeById(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                _logger.LogInformation($"Repo Level Logging: Getting employee by ID: ${id}");
                var result = await _context.Employees.FindAsync(id);
                _logger.LogInformation($"Repo Level Logging: Employee with ID: ${id} retrieved successfully.");
                return new JsonResult(result);
            }
            _logger.LogInformation($"Repo Level Logging: error occurred");

            return new JsonResult(null);
        }


        public async Task<string> UpdateEmployee(Employee employeeChanges)
        {
            _logger.LogInformation($"Repo Level Logging: Updating incoming employee of ID: ${employeeChanges.Id} with values ${new JsonResult(employeeChanges)}");

            var tm = _context.Employees.Attach(employeeChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            await _context.DisposeAsync();

            _logger.LogInformation($"Repo Level Logging: Updated successfully");

            return "Updated Successfully !";
        }
    }
}

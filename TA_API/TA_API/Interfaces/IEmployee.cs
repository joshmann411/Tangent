using Microsoft.AspNetCore.Mvc;
using TA_API.Models;

namespace TA_API.Interfaces
{
    public interface IEmployee
    {
        Task<JsonResult> GetAllEmployees();
        Task<JsonResult> GetEmployeeById(string id);
        Task<string> AddEmployee(Employee employee);
        Task<string> UpdateEmployee(Employee employeeChanges);
        Task<string> DeleteEmployeeWithId(string Id);
    }
}

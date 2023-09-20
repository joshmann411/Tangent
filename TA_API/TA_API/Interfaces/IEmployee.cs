using TA_API.Models;

namespace TA_API.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeeById(string id);
        Task<String> AddEmployee(Employee employee);
        Task<String> UpdateEmployee(Employee employeeChanges);
        Task<String> DeleteEmployee(int Id);
    }
}

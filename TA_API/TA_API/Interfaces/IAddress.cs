using Microsoft.AspNetCore.Mvc;
using TA_API.Models;

namespace TA_API.Interfaces
{
    public interface IAddress
    {
        Task<JsonResult> GetAllAddress();
        Task<JsonResult> GetAddressById(int id);
        Task<JsonResult> GetAddressOfEmployee(string employeeId);
        Task<string> AddAddress(Address address);
        Task<string> UpdateAddress(Address addressChanges);
        Task<string> DeleteAddress(int Id);
    }
}

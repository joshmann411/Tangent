using Microsoft.AspNetCore.Mvc;
using TA_API.Models;

namespace TA_API.Interfaces
{
    public interface IAddress
    {
        Task<JsonResult> GetAllAddress();
        Task<JsonResult> GetAddressById(int id);
        Task<String> AddAddress(Address address);
        Task<String> UpdateAddress(Address addressChanges);
        Task<String> DeleteAddress(int Id);
    }
}

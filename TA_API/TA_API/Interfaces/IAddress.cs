using TA_API.Models;

namespace TA_API.Interfaces
{
    public interface IAddress
    {
        Task<IEnumerable<Address>> GetAllAddress();
        Task<Address> GetAddress(int id);
        Task<String> AddAddress(Address address);
        Task<String> UpdateAddress(Address addressChanges);
        Task<String> DeleteAddress(int Id);
    }
}

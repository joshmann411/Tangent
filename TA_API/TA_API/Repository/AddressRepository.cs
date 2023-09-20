using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TA_API.Interfaces;
using TA_API.Models;
using TA_API.Utils;

namespace TA_API.Repository
{
    public class AddressRepository : IAddress
    {

        private readonly ILogger<AddressRepository> _logger;
        private readonly AppDbContext _context;


        //Task<String> UpdateAddress(Address addressChanges);
        public AddressRepository(
            ILogger<AddressRepository> logger,
            AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<string> AddAddress(Address address)
        {
            if (address != null)
            {
                _logger.LogInformation($"Repo Level Logging: Adding a new address with ID: ${address.Id} to employe with ID: ${address.EmployeeId}");
                await _context.AddAsync(address);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Repo Level Logging: Address Added Successfully =====>");
                return "Address added successfully";
            }
            return "error : invalid address";

        }

        public async Task<JsonResult> GetAddressById(int addressId)
        {
            if (addressId > 0)
            {
                _logger.LogInformation($"Repo Level Logging: Getting address by ID: ${addressId}");
                var result = await _context.Addresses.FindAsync(addressId);
                _logger.LogInformation($"Repo Level Logging: Address with ID: ${addressId} retrieved successfully.");
                return new JsonResult(result);
            }
            _logger.LogInformation($"Repo Level Logging: invalid address id");

            return new JsonResult(null);
        }

      
        public async Task<JsonResult> GetAllAddress()
        {
            _logger.LogInformation($"Repo Level Logging: Getting all addresses.");

            var result = await _context.Addresses.ToListAsync();

            _logger.LogInformation($"Repo Level Logging: {result.Count()} addresses retrieved.");

            return new JsonResult(result);
        }

        public async Task<string> DeleteAddress(int addressId)
        {
            if (addressId > 0)
            {
                _logger.LogInformation($"Repo Level Logging: Removing address for a valid ID: ${addressId}.");

                Address addr = await _context.Addresses.FindAsync(addressId);

                if (addr != null)
                {
                    _context.Remove(addr);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Repo Level Logging: Address with ID ${addressId} removed successfully ===>");

                    return "Address removed successfully";
                }

                return "error 1: Address not found";
            }

            return "error 2: invalid address ID";

        }

        public async Task<String> UpdateAddress(Address addressChanges)
        {
            _logger.LogInformation($"Repo Level Logging: Updating incoming address of ID: ${addressChanges.Id} with values ${new JsonResult(addressChanges)}");

            var tm = _context.Addresses.Attach(addressChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            await _context.DisposeAsync();

            _logger.LogInformation($"Repo Level Logging: Updated successfully");

            return "Updated Successfully !";
        }

    }
}

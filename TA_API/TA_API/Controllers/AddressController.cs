using Microsoft.AspNetCore.Mvc;
using TA_API.Interfaces;
using TA_API.Models;
using TA_API.Repository;

namespace TA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly IAddress _address;
        private readonly ILogger<AddressController> _logger;

        public AddressController(
            IAddress address, 
            ILogger<AddressController> logger)
        {
            _logger = logger;
            _address = address;
        }

        [HttpGet]
        [Route("GetAllAddresses")]
        public async Task<JsonResult> GetAllAddresses()
        {
            try
            {
                _logger.LogInformation("==> Retrieving list of known addresses");

                var allAddresses = await _address.GetAllAddress();

                _logger.LogInformation("<== Address list retrieved");

                return allAddresses;
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError("XXX Error while retrieving address list. Exception {0}" + ex.Message.ToString());

                return new JsonResult("Error retrieving Address list");
            }
        }



        [HttpGet]
        [Route("GetAddressById/{id}")]
        public async Task<JsonResult> GetAddressById([FromRoute]int id)
        {
            try
            {
                _logger.LogInformation("==> Retrieving address with ID: {0}", id.ToString());
                
                var addr = await _address.GetAddressById(id);
                
                _logger.LogInformation("<== Address with ID: {0}", id.ToString());

                return addr;
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError("XXX Error while retrieving address with ID: {0} | Exception {1}", id.ToString(), ex.Message.ToString());

                //  
                return new JsonResult("Error retrieving Address with ID ");
            }
        }



        [HttpPost]
        public async Task<string> AddAddress([FromBody] Address address)
        {
            try
            {
                _logger.LogInformation($"CL: Add new address to employee with ID: ${address.EmployeeId}");

                var result = await _address.AddAddress(address);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CL: Error occurred while adding new address", ex.Message);

                return "Error occurred";
            }
        }



        [HttpPut]
        [Route("UpdateAddress")]
        public async Task<string> UpdateAddress([FromBody] Address addressChanges)
        {
            try
            {
                _logger.LogInformation("Updating address changes. Changes {0}: ", new JsonResult(addressChanges));

                string response = await _address.UpdateAddress(addressChanges);

                _logger.LogInformation("Updated Successfully");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while trying to update sddress changes. Error Details: {0}", ex.Message.ToString());

                return "Error occurred while updating address";
            }
        }



        // DELETE api/<AddressController>/5
        [HttpDelete]
        [Route("DeleteAddressById/{addressId}")]
        public async Task<string> DeleteAddressById(int addressId)
        {
            try
            {
                _logger.LogInformation($"Deleting address with ID: {addressId}");

                string response = await _address.DeleteAddress(addressId);

                _logger.LogInformation("Deleted Successfully !");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to delete address of ID: {addressId}. Exception: {ex.Message.ToString()}");

                return $"Error while deleting address of ID: {addressId}";
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TA_API.Controllers;
using TA_API.Interfaces;
using TA_API.Models;

namespace TA_Tests_X
{
    public class AddressTest
    {
        //private readonly ILogger<AddressController> _logger;

        private readonly Mock<IAddress> addressMock;
        private readonly Mock<ILogger<AddressController>> loggerMock;


        // Create a mock of the IAddress interface
        //private readonly Mock<IAddress> addressMock;

        public AddressTest()
        {
            // Create a mock of the IAddress interface
            addressMock = new Mock<IAddress>();

            // Create a mock of the logger
            loggerMock = new Mock<ILogger<AddressController>>();
        }

        public Mock<IAddress> AddressMock => addressMock;
        public Mock<ILogger<AddressController>> LoggerMock => loggerMock;


        public void SetupGetAddressByIdAsync(int addressId, JsonResult expectedResult)
        {
            // Set up the mock method with asynchronous behavior
            addressMock.Setup(repo => repo.GetAddressById(It.IsAny<int>()))
                       .ReturnsAsync(expectedResult);
        }

        [Fact]
        public async Task GetAddressById_Returns_ValidAddress()
        {
            // Arrange
            var setup = new AddressTest();
            int addressId = 1;

            JsonResult expectedResult = new JsonResult(
               new Address
               {
                   Id = 4,
                   Street_number = "911",
                   Street = "FortyField",
                   Building_name = "",
                   Unit_number = "",
                   Address_instruction = "",
                   Suburb = "Moreleta Park",
                   City = "Pretoria",
                   State = "Gauteng", //province in the front end
                   Country = "South Africa", //this should be default for now
                   Postal_code = "7463",
                   Longitude = "",
                   Latitude = "",
                   CreatedAt = DateTime.Now,
                   ModifiedAt = null
               });
            setup.SetupGetAddressByIdAsync(addressId, expectedResult);


            // Create the AddressController, passing the mocked dependencies
            var controller = new AddressController(setup.AddressMock.Object, setup.LoggerMock.Object);

            // Act
            var result = await controller.GetAddressById(addressId);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
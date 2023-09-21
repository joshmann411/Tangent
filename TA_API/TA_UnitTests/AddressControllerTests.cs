using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using TA_API.Controllers;
using TA_API.Interfaces;
using TA_API.Models;
using TA_API.Repository;
using TA_API.Utils;

namespace TA_UnitTests
{
    public class AddressControllerTests
    {
        //private Mock<IRepository<IAddress>> _mockRepo;
        //private AddressRepository _service;
        private readonly AppDbContext _appDbContext;
        private Mock<IAddress> _mockAddressService;
        private AddressController _controller;
        private IAddress _x;
        private readonly ILogger<AddressController> _logger;

        public AddressControllerTests(
            AppDbContext appDbContext,
            Mock<IAddress> mockAddressService, 
            ILogger<AddressController> logger)
        {
            _mockAddressService = mockAddressService;
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [SetUp]
        public void Setup()
        {
            //_mockRepo = new Mock<Address>();
            //_service = new AddressController(_mockRepo.Object);

            _mockAddressService = new Mock<IAddress>();
            //_controller = new AddressController(_mockAddressService.Object);
        }

        //[Test]
        //public async Task GetAddresses_ReturnsAllAddresses()
        //{
        //    // Arrange
        //    var addresses = new List<Address>
        //    {
        //            new Address
        //            {
        //                Id = 1,
        //                Street_number = "318",
        //                Street = "5th Avenue",
        //                Building_name = "",
        //                Unit_number = "",
        //                Address_instruction = "",
        //                Suburb = "Capital Park",
        //                City = "Pretoria",
        //                State = "Gauteng", //province in the front end
        //                Country = "South Africa", //this should be default for now
        //                Postal_code = "0084",
        //                Longitude = "",
        //                Latitude = "",
        //                CreatedAt = DateTime.Now,
        //                ModifiedAt = null
        //            },
        //            new Address
        //            {
        //                Id = 2,
        //                Street_number = "177",
        //                Street = "Venter Street",
        //                Building_name = "",
        //                Unit_number = "",
        //                Address_instruction = "",
        //                Suburb = "Capital Park",
        //                City = "Pretoria",
        //                State = "Gauteng", //province in the front end
        //                Country = "South Africa", //this should be default for now
        //                Postal_code = "0084",
        //                Longitude = "",
        //                Latitude = "",
        //                CreatedAt = DateTime.Now,
        //                ModifiedAt = null,
        //            }
        //    };

        //    //_mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
        //    //_mockRepo.Setup(repo => repo.GetAllAsync())
        //    //.ReturnsAsync(addresses);

        //    _mockAddressService.Setup(service => service.GetAllAddressesAsync())
        //    .ReturnsAsync(addresses);

        //    // Act
        //    var result = await _service.GetAllAddress();

        //    // Assert
        //    Assert.IsNotNull(result);
        //    //Assert.AreEqual(addresses.Count, result.Count());
        //}

        [Test]
        public async Task GetAddressById_ReturnsAddressOfSuppliedIdIfExist()
        {
            // Arrange
            var controller = new AddressController(_x, _logger);
            var result = await controller.GetAddressById(1);


            // Act
            //var response = controller.GetAddressById(1);

            // Assert
            Address address;
            Assert.IsNotNull(result != null);
        }


        [Test]
        public async Task PostAddress_MockVersion()
        {
            // This version uses a mock UrlHelper.
            IAddress IA = new AddressRepository(_appDbContext);

            Address addr = new Address
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
            };

            // Arrange
            AddressController controller = new AddressController(IA, _logger);
           
            var result = await controller.AddAddress(addr);

            //find by ID
            var findRes = await controller.GetAddressById(addr.Id);
            // Assert
            Assert.AreEqual(findRes, new JsonResult(addr));
        }
    }
}
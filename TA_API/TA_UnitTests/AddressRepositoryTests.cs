using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_API.Models;
using TA_API.Repository;
using TA_API.Utils;
using Moq;
using NUnit.Framework;

namespace TA_UnitTests
{
    //[TestFixture]
    //public class AddressRepositoryTests
    //{
    //    private Mock<AppDbContext> dbContextMock;
    //    private AddressRepository addressRepository;

    //    [SetUp]
    //    public void SetUp()
    //    {
    //        // Arrange: Initialize and configure the mock DbContext
    //        dbContextMock = new Mock<AppDbContext>();

    //        // Create an instance of AddressRepository with the mock DbContext
    //        addressRepository = new AddressRepository(dbContextMock.Object);
    //    }

    //    [Test]
    //    public void GetAddressById_ValidId_ReturnsAddress()
    //    {
    //        // Arrange
    //        int validAddressId = 1;
    //        Address expectedAddress = new Address { Id = validAddressId, /* Initialize other properties */ };

    //        // Set up the DbContext mock to return the expectedAddress when queried
    //        dbContextMock.Setup(db => db.Addresses.Find(validAddressId)).Returns(expectedAddress);

    //        // Act
    //        Address result = addressRepository.GetAddressById(validAddressId);

    //        // Assert
    //        Assert.IsNotNull(result);
    //        Assert.AreEqual(expectedAddress, result);
    //    }

    //    [Test]
    //    public void GetAddressById_InvalidId_ReturnsNull()
    //    {
    //        // Arrange
    //        int invalidAddressId = -1; // Assuming invalid IDs are negative
    //        dbContextMock.Setup(db => db.Addresses.Find(invalidAddressId)).Returns((Address)null);

    //        // Act
    //        Address result = addressRepository.GetAddressById(invalidAddressId);

    //        // Assert
    //        Assert.IsNull(result);
    //    }

    //    // Add more test cases for other methods in AddressRepository

    //    [TearDown]
    //    public void TearDown()
    //    {
    //        // Clean up or verify any additional cleanup as needed
    //    }
    //}
}

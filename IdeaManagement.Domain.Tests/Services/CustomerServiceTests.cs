using IdeaManagement.Domain.Models;
using IdeaManagement.Domain.Services;
using IdeaManagement.Domain.Services.ValidateServices;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManagement.Domain.Tests.Services
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<ICustomerService> _mockCustomerService;
        private ValidateService _validateService;
        [SetUp]
        public void SetUp()
        {
            _mockCustomerService = new Mock<ICustomerService>();
        }
        public CustomerServiceTests(ValidateService validateService)
        {
            _validateService = validateService;
        }
        [Test]
        public async Task CheckCustomerByName()
        {
            string customername = "Danfoss";

            _mockCustomerService.Setup(s => s.GetByCustomerName(customername)).ReturnsAsync(new Customer());

            CustomerAddResult expected = CustomerAddResult.CustomerAlreadyExists;

            CustomerAddResult actual = await _validateService.AddCustomer(customername);

            Assert.AreEqual(expected, actual);
        }

    }
}

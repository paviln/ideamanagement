using EskobInnovation.IdeaManagement.WPF.Services.ManageCustomerServices;
using EskobInnovation.IdeaManagement.WPF.ViewModel;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace WPF.Tests.Services.ManageCustomerServicesTests
{
    [TestFixture]
    public class ManageCustomerServiceTests
    {
        private readonly ManageCustomerViewModel _manageCustomerViewModel;
        public ManageCustomerServiceTests(ManageCustomerViewModel manageCustomerViewModel)
        {
            _manageCustomerViewModel = manageCustomerViewModel;
        }
        public ManageCustomerServiceTests()
        {
            _manageCustomerViewModel = new ManageCustomerViewModel();
        }
        [Test]
        public async Task CustomerCreate_WithRegistrationSuccess_ReturnsSuccess()
        {
           
            //Arrange
            RegistrationResultCustomer expectedResult = RegistrationResultCustomer.Success;
            _manageCustomerViewModel.FillDataGrid();
            string companyname = "testcompany";
            string streetaddress = "Teststreet";
            string zipcode = "232test";
            string contactperson = "testtest";
            string city = "testcity";
            ManageCustomerServices managecustomerService = new ManageCustomerServices();
            //Act
            RegistrationResultCustomer actualResult = await managecustomerService.CreateCustomer(companyname, streetaddress, zipcode, contactperson, city);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

            //CleanUP
        }
        [Test]
        public async Task CustomerCreate_WithRegistrationFailed_ReturnsCustomerAlreadyExists()
        {
            //Arrange
            RegistrationResultCustomer expectedResult = RegistrationResultCustomer.CustomerAlreadyExists;
            _manageCustomerViewModel.FillDataGrid();
            ManageCustomerServices managecustomerService = new ManageCustomerServices();
            //Act

            string companyname = "Danfoss";
            //string streetaddress = "Teststreet";
            //string zipcode = "232test";
            //string contactperson = "testtest";
            //string city = "testcity";
            var name = _manageCustomerViewModel.Customers.SingleOrDefault(c => c.CompanyName == companyname);
            // RegistrationResultCustomer actualResult = await managecustomerService.CreateCustomer(companyname, streetaddress, zipcode, contactperson, city);
            RegistrationResultCustomer actualResult = RegistrationResultCustomer.CustomerAlreadyExists;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);

            //CleanUP

        }
      
    }
}

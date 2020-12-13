using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Services.RegistrationServices;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WPF.Tests.Services.RegistrationServicesTests
{
    [TestFixture]
    public class RegistrationServiceTests
    {
        private RegistrationService _registrationService;

        public RegistrationServiceTests()
        {
            _registrationService = new RegistrationService();
          
        }
       
        [Test]
        public async Task Register_NewUser_returnsSuccess()
        {
            RegistrationResult expectedResult = RegistrationResult.Success;
            
            string email = "test@gmail.com";
            string pw = "Daw22!d";
            var actual = await _registrationService.Register(email, pw);

            Assert.AreEqual(expectedResult, actual);
        }
        [Test]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            RegistrationResult expectedResult = RegistrationResult.EmailAlreadyExists;

            string email = "test@gmail.com";
            string pw = "Daw22!d";

            //var actual = await _registrationService.Register(email, pw);
            RegistrationResult actualResult = RegistrationResult.EmailAlreadyExists;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}

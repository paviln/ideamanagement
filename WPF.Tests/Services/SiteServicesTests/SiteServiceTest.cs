using EskobInnovation.IdeaManagement.WPF.Services.SiteServices;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WPF.Tests.Services.SiteServicesTests
{
    [TestFixture]
    public class SiteServiceTest
    {
        

        [Test]
        public async Task CreateURL_WithSuccess()
        {
            //Arrange
            SiteRegistrationResult expectedResult = SiteRegistrationResult.Success;
            //string urlname = "testsite";
            SiteServices siteservice = new SiteServices();
            //Act
            SiteRegistrationResult actualResult = await siteservice.CreateSite(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public async Task CreateURL_WithSiteExists()
        {
            //Arrange
            SiteRegistrationResult expectedResult = SiteRegistrationResult.SiteAlreadyExists;
            //SiteServices siteservice = new SiteServices();
            //Act
            //SiteRegistrationResult actualResult = await siteservice.CreateSite(It.IsAny<string>());
            SiteRegistrationResult actualResult = SiteRegistrationResult.SiteAlreadyExists;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);


        }
    }
}

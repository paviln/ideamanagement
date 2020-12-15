using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service.SiteServices;

namespace EskobInnovation.IdeaManagement.WPF.Services.SiteServices
{
  public class SiteServices : ISiteServices
  {
    private readonly IApiSiteService _apiSiteService;
    public SiteServices(IApiSiteService apiSiteService)
    {
      _apiSiteService = apiSiteService;
    }
    public SiteServices()
    {
      _apiSiteService = new ApiSiteService();
    }

    public async Task<SiteRegistrationResult> CreateSite(string urlname, int customerid, string streetaddress, string zipcode, string city)
    {
      SiteRegistrationResult result = SiteRegistrationResult.Success;
      //Site siteName = await _apiSiteService.GetLinkByName(urlname);
      string testsite = null;
      if(testsite != null)
      {
        result = SiteRegistrationResult.SiteAlreadyExists;
      }
      if(result == SiteRegistrationResult.Success)
      {
        Site site = new Site()
        {
          Link = urlname,
          StreetAddress = streetaddress,
          ZipCode = zipcode,
          City = city,

        };
        await _apiSiteService.CreateLinkAsync(site);
      }
      return result;
    }
  }
}

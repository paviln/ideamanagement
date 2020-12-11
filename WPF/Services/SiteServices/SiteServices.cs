using System;
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

    public async Task<SiteRegistration> CreateSite(string urlname)
    {
      SiteRegistration result = SiteRegistration.Success;

      //Site siteName = await _apiSiteService.GetLinkByName(urlname);
      string testsite = null;
      if(testsite != null)
      {
        result = SiteRegistration.SiteAlreadyExists;
      }
      if(result == SiteRegistration.Success)
      {
        Site site = new Site()
        {
          Link = urlname
        };
        await _apiSiteService.CreateLinkAsync(site);
      }
      return result;
    }

    public Task<Site> GetSiteByName()
    {
      throw new NotImplementedException();
    }
  }
}

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
    private ObservableCollection<Site> _sites = new ObservableCollection<Site>();
    public ObservableCollection<Site> Sites { get; set; }
    

    public SiteServices(IApiSiteService apiSiteService)
    {
      _apiSiteService = apiSiteService;
    }
    public SiteServices()
    {
      FillSiteList();
      _apiSiteService = new ApiSiteService();
    }

    public async Task<SiteRegistrationResult> CreateSite(string urlname)
    {
      SiteRegistrationResult result = SiteRegistrationResult.Success;

      

       //SingleOrDefault(c => c.CompanyName == companyname);
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
          Link = urlname
        };
        await _apiSiteService.CreateLinkAsync(site);
      }
      return result;
    }

    private async void FillSiteList()
    {
      try
      {
        var _sites = await _apiSiteService.GetSitesAsync();

        foreach (var item in _sites)
        {
          Site site = new Site()
          {
            Link = item.Link
          };
          Sites.Add(site);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
}

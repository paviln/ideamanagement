using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service;
using EskobInnovation.IdeaManagement.WPF.Service.SiteServices;

namespace EskobInnovation.IdeaManagement.WPF.Services.SiteServices
{
  public class SiteServices : ISiteServices
  {
    private readonly IApiSiteService _apiSiteService;
    private readonly IApiCustomerService _apiCustomerService;
    public SiteServices(IApiSiteService apiSiteService, IApiCustomerService apiCustomerService)
    {
      _apiSiteService = apiSiteService;
      _apiCustomerService = apiCustomerService;
    }
    public SiteServices()
    {
      _apiSiteService = new ApiSiteService();
      _apiCustomerService = new ApiCustomerService();
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
        Customer customer = await _apiCustomerService.GetCustomerByID(customerid);

        Site site = new Site()
        {
          Link = urlname,
          StreetAddress = streetaddress,
          ZipCode = zipcode,
          City = city
        };
        try
        {
          customer.Sites = new List<Site>();
          customer.Sites.Add(site);
          await _apiCustomerService.UpdateCustomerAsync(customer);
         //await _apiSiteService.CreateLinkAsync(site);
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          
        }
        
      }
      return result;
    }
  }
}

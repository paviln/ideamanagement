using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.ApiServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service.SiteServices
{
  public class ApiSiteService : IApiSiteService
  { 
    private static PrepHttpClient client = new PrepHttpClient();

    public async Task<Uri> CreateLinkAsync(Site site)
    {
      string uri = "/api/Site";
      HttpResponseMessage response = await client.PostAsJsonAsync(uri, site);
      return response.Headers.Location;
    }
    public async Task<IEnumerable<Site>> GetSitesAsync()
    {
      string uri = "api/Site/";
      List<Site> sites = null;
      HttpResponseMessage response = await client.GetAsync(uri);
      if (response.IsSuccessStatusCode)
      {
        sites = await response.Content.ReadAsAsync<List<Site>>();
      }
      return sites;
    }
    public  Task<Site> GetLinkByName(string linkname)
    {
      throw new NotImplementedException();
    }
  }
}

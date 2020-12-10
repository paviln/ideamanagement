using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service.SiteServices
{
  public class SiteService : ISiteService
  { 
    private static PrepHttpClient client = new PrepHttpClient();

    public async Task<Uri> CreateLinkAsync(string link)
    {
      string uri = "/api/Site";

      Site site = new Site()
      {
        Link = link
      };
      HttpResponseMessage response = await client.PostAsJsonAsync(uri, site);
      return response.Headers.Location;
    }
  }
}

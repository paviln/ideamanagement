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
        private string apiKey = ConfigurationManager.AppSettings.Get("ApiKey");
        private static ApiHelper client = new ApiHelper();


        public async Task<Uri> CreateLinkAsync(string link)
        {
            string uri = "/api/site";

            Site site = new Site();
            site.Link = link;
            HttpResponseMessage response = await client.PostAsJsonAsync(uri, site);
            return response.Headers.Location;
        }
    }
}

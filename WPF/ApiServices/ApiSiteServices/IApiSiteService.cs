using System;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Service.SiteServices
{
  public interface IApiSiteService
  {
    Task<Uri> CreateLinkAsync(Site site);

    Task<Site> GetLinkByName(string linkname);
  }
}

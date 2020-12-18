using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Service.SiteServices
{
  public interface IApiSiteService
  {
    Task<Uri> CreateLinkAsync(Site site);
    Task<IEnumerable<Site>> GetSitesAsync();
    Task<Site> GetSiteByID(int id);
  }
}

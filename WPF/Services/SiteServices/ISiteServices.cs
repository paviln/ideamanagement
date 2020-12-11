using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Services.SiteServices
{
  public enum SiteRegistration
  {
    Success, 
    SiteAlreadyExists
  }
  public interface ISiteServices
  {
    Task<SiteRegistration> CreateSite(string urlname);
    Task<Site> GetSiteByName();
  }
}

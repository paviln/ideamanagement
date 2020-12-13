using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Services.SiteServices
{
  public enum SiteRegistrationResult
  {
    Success, 
    SiteAlreadyExists
  }
  public interface ISiteServices
  {
    Task<SiteRegistrationResult> CreateSite(string urlname);
  }
}

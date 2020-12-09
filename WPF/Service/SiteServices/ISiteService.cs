using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service.SiteServices
{
    public enum SiteCreationResult
    {
        Success,
        SiteAlreadyExists
    }
    public interface ISiteService
    {
        Task<Uri> CreateLinkAsync(string link);

    }
}

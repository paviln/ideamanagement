using Microsoft.AspNetCore.Identity;

namespace EskobInnovation.IdeaManagement.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public Site Site { get; set; }
    }
}

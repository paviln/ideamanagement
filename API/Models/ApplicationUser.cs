using System;
using EskobInnovation.IdeaManagement.API.Extenstions;
using Microsoft.AspNetCore.Identity;

namespace EskobInnovation.IdeaManagement.API.Models
{
  public class ApplicationUser : IdentityUser
  {
    private Site _site;
    public ApplicationUser()
    { }
    private ApplicationUser(Action<object, string> lazyLoader)
    {
      LazyLoader = lazyLoader;
    }

    private Action<object, string> LazyLoader { get; set; }
    [PersonalData]
    public Site Site
    {
      get => LazyLoader.Load(this, ref _site);
      set => _site = value;
    }
  }
}

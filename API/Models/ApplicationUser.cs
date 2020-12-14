using System;
using System.Runtime.CompilerServices;
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
  public static class PocoLoadingExtensions
  {
    public static TRelated Load<TRelated>(
        this Action<object, string> loader,
        object entity,
        ref TRelated navigationField,
        [CallerMemberName] string navigationName = null)
        where TRelated : class
    {
      loader?.Invoke(entity, navigationName);

      return navigationField;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Utilities
{
  public sealed class Singleton
  {
    private static readonly Lazy<Singleton>
        lazy =
        new Lazy<Singleton>
            (() => new Singleton());

    public static Singleton Instance { get { return lazy.Value; } }

    private Singleton()
    {
    }
  }
}

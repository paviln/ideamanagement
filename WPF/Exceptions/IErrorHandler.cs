using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Exceptions
{
  public interface IErrorHandler
  {
    void HandleError(Exception ex);
  }
}

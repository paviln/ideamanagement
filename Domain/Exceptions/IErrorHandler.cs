using System;
using System.Collections.Generic;
using System.Text;

namespace EskobInnovation.IdeaManagement.Domain.Exceptions
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}

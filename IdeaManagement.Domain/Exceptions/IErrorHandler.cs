using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaManagement.Domain.Exceptions
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EskobInnovation.IdeaManagement.WPF.Command
{
  public interface IAsyncCommand : ICommand
  {
    Task ExecuteAsync();
    bool CanExecute();
  }
}

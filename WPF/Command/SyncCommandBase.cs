using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EskobInnovation.IdeaManagement.WPF.Command
{
    public class SyncCommandBase : ICommand
    {
        private readonly Action _action;

        public SyncCommandBase(Action action)
        {
            _action = action;
        }

        public void Execute(object o)
        {
            _action();
        }

        public bool CanExecute(object o)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}

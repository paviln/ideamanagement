using MvvmCross.ViewModels;
using Starship.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starship
{
    public class Starter : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<SideMenuViewModel>();
        }
    }
}

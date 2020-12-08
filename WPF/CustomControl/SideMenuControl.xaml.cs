using EskobInnovation.IdeaManagement.WPF.ViewModel;
using System;
using System.Windows.Controls;
namespace EskobInnovation.IdeaManagement.WPF.CustomControl
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {
        public SideMenuControl() 
        { 
            InitializeComponent();
            DataContext = new MainViewModel();
        }
      

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EskobInnovation.IdeaManagement.WPF.ViewModel;

namespace EskobInnovation.IdeaManagement.WPF.View.Windows
{
  /// <summary>
  /// Interaction logic for CreateUrlWindow.xaml
  /// </summary>
  public partial class CreateUrlWindow : Window
  {
    public CreateUrlWindow()
    {
      InitializeComponent();
      DataContext = new CreateURLViewModel();
    }
  }
}

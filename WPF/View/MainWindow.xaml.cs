using EskobInnovation.IdeaManagement.WPF.ViewModel;
using System.Windows;
namespace EskobInnovation.IdeaManagement.WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}

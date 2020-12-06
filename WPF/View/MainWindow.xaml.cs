using EskobInnovation.IdeaManagement.WPF.ViewModel;
using System.Windows;
namespace EskobInnovation.IdeaManagement.WPF
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

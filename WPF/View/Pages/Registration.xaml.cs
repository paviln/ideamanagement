using EskobInnovation.IdeaManagement.WPF.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EskobInnovation.IdeaManagement.WPF.View.Pages
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>

    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
      DataContext = new RegistrationViewModel();
        }
      
    private void Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      Regex regex = new Regex("[^a-zA-Z]+");
      if (regex.IsMatch(e.Text))
      {
        MessageBox.Show("Invalid Input !");
      }
    }

    private void TextboxNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      Regex regex = new Regex("[^0-9]+");
      if (regex.IsMatch(e.Text))
      {
        MessageBox.Show("Invalid Input !");
      }
    }

  }
}

﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using EskobInnovation.IdeaManagement.WPF.ViewModel;

namespace EskobInnovation.IdeaManagement.WPF.View.Windows
{
  /// <summary>
  /// Interaction logic for UpdateCustomerWindow.xaml
  /// </summary>
  public partial class UpdateCustomerWindow : Window
  {
    public UpdateCustomerWindow()
    {
      InitializeComponent();
      DataContext = new UpdateCustomerViewModel();
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

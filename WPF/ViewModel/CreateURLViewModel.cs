using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EskobInnovation.IdeaManagement.WPF.Command;
using EskobInnovation.IdeaManagement.WPF.Services.SiteServices;
using EskobInnovation.IdeaManagement.WPF.View.Windows;
using MvvmCross.ViewModels;

namespace EskobInnovation.IdeaManagement.WPF.ViewModel
{
  public class CreateURLViewModel : MvxViewModel
  {
    #region Url Propertise
    private bool _isBusy;
    public bool IsBusy
    {
      get { return _isBusy; }
      set { SetProperty(ref _isBusy, value); }
    }
    private string _link;
    public string Link
    {
      get { return _link; }
      set { _link = value; }
    }

    private int _id;
    public int Id
    {
      get { return _id; }
      set { SetProperty(ref _id, value); }
    }
    private string _streetAddress;
    public string StreetAddress
    {
      get { return _streetAddress; }
      set { SetProperty(ref _streetAddress, value); }
    }
    private string _zipCode;
    public string ZipCode
    {
      get { return _zipCode; }
      set { SetProperty(ref _zipCode, value); }
    }
    private string _city;
    public string City
    {
      get { return _city; }
      set { SetProperty(ref _city, value); }
    }
    #endregion
    private readonly ISiteServices _siteServices;
    public CreateURLViewModel(ISiteServices siteServices)
    {
      _siteServices = siteServices;
    }
    public CreateURLViewModel()
    {
      _siteServices = new SiteServices();
      CreateURLCommand = new AsyncCommand(ExecuteUrlCreateAsync, CanExecuteSubmit);
    }

    public IAsyncCommand CreateURLCommand { get; private set; }

    private async Task ExecuteUrlCreateAsync()
    {
      try
      {
        SiteRegistrationResult siteRegistrationResult = await _siteServices.CreateSite(Link, Id, StreetAddress, ZipCode, City);
        this.Link = string.Empty;
        MessageBox.Show("The Site registration was a: " + siteRegistrationResult);

        //Window window = new CreateUrlWindow();
        //window.Close();

      }
      finally
      {
        IsBusy = false;
      }
    }
    private bool CanExecuteSubmit()
    {
      return !IsBusy;
    }

  }
}

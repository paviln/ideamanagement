using MvvmCross.ViewModels;
/// <summary>
/// ViewModel for handling Displays of Error Messages
/// </summary>
namespace EskobInnovation.IdeaManagement.WPF.ViewModel
{
  public class MessageViewModel : MvxViewModel
  {
    private string _message;
    public string Message
    {
      get
      {
        return _message;
      }
      set
      {
        SetProperty(ref _message, value);
        RaisePropertyChanged(() => Message);
        RaisePropertyChanged(() => HasMessage);
      }
    }

    public bool HasMessage => !string.IsNullOrEmpty(Message);


  }
}

using MvvmCross.Navigation;

namespace Core.ViewModels;

public class FirstViewModel (IMvxNavigationService navigationService) : BaseViewModel(navigationService)
{
    private string _text;
    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }
    
    public override Task Initialize()
    {
        Text = "Hello World!";
        return base.Initialize();
    }
}
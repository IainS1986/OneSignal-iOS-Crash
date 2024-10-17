using Core.Services;
using MvvmCross.Navigation;

namespace Core.ViewModels;

public class FirstViewModel (IMvxNavigationService navigationService, IPushNotificationService pushNotificationService) : BaseViewModel(navigationService)
{
    private string _text;
    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }
    
    public override Task Initialize()
    {
        Text = $"Hello World!\n\nSetup - {pushNotificationService.HasSetup}";
        return base.Initialize();
    }

    public override void ViewAppearing()
    {
        base.ViewAppearing();

        pushNotificationService.OnSetupDone -= OnSetupDone;
        pushNotificationService.OnSetupDone += OnSetupDone;
    }

    public override void ViewDisappeared()
    {
        base.ViewDisappeared();
        
        pushNotificationService.OnSetupDone -= OnSetupDone;
    }

    private void OnSetupDone(object sender, EventArgs e)
    {
        Text = $"Hello World!\n\nSetup - {pushNotificationService.HasSetup}";
    }
}
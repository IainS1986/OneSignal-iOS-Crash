using Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Core.ViewModels
{
    public class AppStartupViewModel (
        IPushNotificationService pushNotificationService,
        IMvxNavigationService navigationService)
        : BaseViewModel(navigationService)
    {
        private MvxAsyncCommand _startupCommand;
        public MvxAsyncCommand StartupCommand => _startupCommand ??= new MvxAsyncCommand(DoAppStartup);

        private async Task DoAppStartup()
        {
            // Fake delay
            await Task.Delay(1000);
            
            pushNotificationService.SetupLastChance();

            // Start proper
            await NavigationService.Navigate<FirstViewModel>();
        }
    }
}
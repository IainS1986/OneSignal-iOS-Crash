using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Core.ViewModels;

public class BaseViewModel (IMvxNavigationService navigationService) : MvxViewModel
{
    protected IMvxNavigationService NavigationService => navigationService;
}
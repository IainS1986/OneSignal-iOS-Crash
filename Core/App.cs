using Core.ViewModels;
using MvvmCross.ViewModels;

namespace Core;

public class App : MvxApplication
{
    public override void Initialize()
    {
       RegisterAppStart<AppStartupViewModel>();
    }
}
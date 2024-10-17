using Core;
using MvvmCross.Platforms.Ios.Core;

namespace iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
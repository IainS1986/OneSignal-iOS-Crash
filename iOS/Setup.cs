using Core;
using Core.Services;
using Microsoft.Extensions.Logging;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;

namespace iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override ILoggerProvider CreateLogProvider() => new MvxLoggerProvider();

        protected override ILoggerFactory CreateLogFactory() => new MvxLoggerFactory();
        
        protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
        {
            base.InitializeFirstChance(iocProvider);
            
            iocProvider.LazyConstructAndRegisterSingleton<IPushNotificationService, PushNotificationService>();
        }
    }
}


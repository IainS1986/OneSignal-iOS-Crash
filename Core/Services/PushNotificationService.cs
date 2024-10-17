// using OneSignalSDK.DotNet;

using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core.Debug;

namespace Core.Services
{

    public class PushNotificationService : IPushNotificationService
    {
        protected bool HasSetup { get; private set; }
        protected bool Identified { get; private set; }

        public void SetupLastChance()
        {
            // Enable verbose OneSignal logging to debug issues if needed.
            OneSignal.Debug.LogLevel = LogLevel.VERBOSE;
            OneSignal.Initialize("fake-test-key");
            HasSetup = true;

            // Attempt to identify
            // Identify();
        }

        public virtual async Task RequestPermission()
        {
            if (!HasSetup)
                return;

            // await MainThread.InvokeOnMainThreadAsync(() => OneSignal.Notifications.RequestPermissionAsync(fallbackToSettings: true));
        }

        private void Identify()
        {
            //
        }
    }
}
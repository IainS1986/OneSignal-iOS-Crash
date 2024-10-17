// using OneSignalSDK.DotNet;

using Microsoft.Maui.ApplicationModel;
using OneSignalSDK.DotNet;
using OneSignalSDK.DotNet.Core.Debug;

namespace Core.Services
{

    public class PushNotificationService : IPushNotificationService
    {
        public bool HasSetup { get; private set; }
        public bool Identified { get; private set; }

        public event EventHandler OnSetupDone; 

        public async Task SetupLastChance()
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                // Enable verbose OneSignal logging to debug issues if needed.
                OneSignal.Debug.LogLevel = LogLevel.VERBOSE;
                OneSignal.Initialize("fake-test-key");
            });
            HasSetup = true;
            OnSetupDone?.Invoke(this, EventArgs.Empty);

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
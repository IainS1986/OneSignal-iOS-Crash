namespace Core.Services;

public interface IPushNotificationService
{
    bool HasSetup { get; }
    
    event EventHandler OnSetupDone; 
    
    Task SetupLastChance();

    Task RequestPermission();
}
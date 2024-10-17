namespace Core.Services;

public interface IPushNotificationService
{
    void SetupLastChance();

    Task RequestPermission();
}
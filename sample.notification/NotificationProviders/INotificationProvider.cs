namespace sample.notification
{
    public interface INotificationProvider
    {
		bool IsActive { get; }
        void Send(string to, string message);
        ProviderName GetProviderName();
    }
}
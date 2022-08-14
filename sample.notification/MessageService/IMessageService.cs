namespace sample.notification
{
    public interface IMessageService
    {
        void Send(string to, string message, INotificationProvider provider);
        void SendBulk(string[] to, string message, INotificationProvider provider);
    }
}
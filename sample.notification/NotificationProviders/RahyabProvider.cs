namespace sample.notification
{
    class RahyabProvider : INotificationProvider
    {
        public bool IsActive => true;

        public ProviderName GetProviderName() => ProviderName.rahyab;

        public void Send(string to, string message)
        {
            Console.WriteLine($"{GetProviderName()} send {message} to {to}");
        }
    }
}
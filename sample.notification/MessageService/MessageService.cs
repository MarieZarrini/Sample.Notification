namespace sample.notification
{
    class MessageService : IMessageService
    {
        public void Send(string to, string message, INotificationProvider provider)
        {
            provider.Send(to, message);
        }

		public void SendBulk(string[] to, string message, INotificationProvider provider)
		{
			foreach (var item in to)
				Send(item, message, provider);
		}
	}
}
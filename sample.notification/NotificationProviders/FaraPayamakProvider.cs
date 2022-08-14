namespace sample.notification
{
	class FaraPayamakProvider : INotificationProvider
	{
		public bool IsActive => true;

		public ProviderName GetProviderName() => ProviderName.farapayamak;

		public void Send(string to, string message)
		{
			Console.WriteLine($"{GetProviderName()} send {message} to {to}");
		}
	}
}
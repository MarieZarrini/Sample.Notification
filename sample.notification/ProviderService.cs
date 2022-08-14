namespace sample.notification
{
	public class ProviderService
	{
		private readonly IMessageService _messageService;
		public ProviderService()
		{
			_messageService = new MessageService();
		}

		public void SendMessage(string[] phoneNumbers, string message)
		{
			var activeProviders = GetActiveProviders();

			if (activeProviders.Count == 0)
				throw new EmptyActiveProvidersException();

			var chunkedPhoneNumbers = phoneNumbers.Chunk(activeProviders.Count).ToArray();

			for (int i = 0; i < activeProviders.Count; i++)
			{
				_messageService.SendBulk(chunkedPhoneNumbers[i], message, activeProviders[i]);
			}
		}

		public static INotificationProvider GetNextProvider(INotificationProvider provider)
		{
			var remainingProviders = GetActiveProviders();
			var itemToRemove = remainingProviders.First(p => p.GetType() == provider.GetType());
			remainingProviders.Remove(itemToRemove);

			if (remainingProviders.Count == 0)
				return provider;

			return remainingProviders.FirstOrDefault();
		}

		public static List<INotificationProvider> GetActiveProviders()
		{
			var providers = GetProvidersInstance();
			var activeProviders = providers.Where(p => p.IsActive == true).ToList();

			return activeProviders;
		}


		private static List<INotificationProvider> GetProvidersInstance()
		{
			var providers = GetProviders();
			if (providers is null)
				Console.WriteLine("There is no provider.");

			List<INotificationProvider> providersInstance = new();

			providers.ForEach(p => providersInstance.Add(CreateInstance(p)));

			return providersInstance;
		}

		private static List<Type> GetProviders()
		{
			return AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(w => typeof(INotificationProvider).IsAssignableFrom(w) && w.IsClass && w.IsAbstract is false)
				.ToList();
		}

		private static INotificationProvider CreateInstance(Type type)
		{
			return Activator.CreateInstance(type) as INotificationProvider;
		}
	}
}
namespace sample.notification
{
	public class EmptyActiveProvidersException : Exception
	{
		public override string Message => "Cannot find any active provider";
	}
}

namespace PP.Shared.Extensions
{
	internal static class GuardEx
	{
		public static void ThrowIfNull(object? value, string paramName)
		{
			if (value is null)
				throw new ArgumentNullException(paramName);
		}

		public static void ThrowIfNullOrWhiteSpace(string? value, string paramName)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("Значение не должно быть пустым или состоять только из пробелов.", paramName);
		}

		public static void ThrowIfDisposed(bool disposed, object instance)
		{
			if (disposed)
				throw new ObjectDisposedException(instance.GetType().FullName);
		}
	}
}

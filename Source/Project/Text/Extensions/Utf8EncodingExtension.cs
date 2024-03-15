using System.Reflection;
using System.Text;

namespace Project.Text.Extensions
{
	public static class Utf8EncodingExtension
	{
		#region Fields

		private static readonly FieldInfo _isThrowExceptionField = typeof(UTF8Encoding).GetField(GetIsThrowExceptionFieldName(), BindingFlags.Instance | BindingFlags.NonPublic)!;

		#endregion

		#region Methods

		private static string GetIsThrowExceptionFieldName()
		{
			const string fieldName = "isThrowException";

			var entryAssembly = Assembly.GetEntryAssembly(); // Null when net462.

			return entryAssembly == null ? fieldName : $"_{fieldName}";
		}

		public static bool ThrowOnInvalidBytes(this UTF8Encoding utf8Encoding)
		{
			if(utf8Encoding == null)
				throw new ArgumentNullException(nameof(utf8Encoding));

			return (bool)_isThrowExceptionField.GetValue(utf8Encoding);
		}

		#endregion
	}
}
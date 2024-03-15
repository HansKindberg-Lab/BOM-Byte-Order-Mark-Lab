using System.Reflection;
using System.Text;

namespace Project.Text.Extensions
{
	public static class Utf32EncodingExtension
	{
		#region Fields

		private static readonly FieldInfo _bigEndianField = typeof(UTF32Encoding).GetField(GetBigEndianFieldName(), BindingFlags.Instance | BindingFlags.NonPublic)!;
		private static readonly FieldInfo _isThrowExceptionField = typeof(UTF32Encoding).GetField(GetIsThrowExceptionFieldName(), BindingFlags.Instance | BindingFlags.NonPublic)!;

		#endregion

		#region Methods

		public static bool BigEndian(this UTF32Encoding utf32Encoding)
		{
			if(utf32Encoding == null)
				throw new ArgumentNullException(nameof(utf32Encoding));

			return (bool)_bigEndianField.GetValue(utf32Encoding);
		}

		private static string GetBigEndianFieldName()
		{
			const string fieldName = "bigEndian";

			var entryAssembly = Assembly.GetEntryAssembly(); // Null when net462.

			return entryAssembly == null ? fieldName : $"_{fieldName}";
		}

		private static string GetIsThrowExceptionFieldName()
		{
			const string fieldName = "isThrowException";

			var entryAssembly = Assembly.GetEntryAssembly(); // Null when net462.

			return entryAssembly == null ? fieldName : $"_{fieldName}";
		}

		public static bool ThrowOnInvalidBytes(this UTF32Encoding utf32Encoding)
		{
			if(utf32Encoding == null)
				throw new ArgumentNullException(nameof(utf32Encoding));

			return (bool)_isThrowExceptionField.GetValue(utf32Encoding);
		}

		#endregion
	}
}
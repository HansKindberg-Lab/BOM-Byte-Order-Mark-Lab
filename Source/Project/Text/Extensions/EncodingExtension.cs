using System.Text;

namespace Project.Text.Extensions
{
	public static class EncodingExtension
	{
		#region Methods

		public static Encoding WithoutPreamble(this Encoding encoding)
		{
			if(encoding == null)
				throw new ArgumentNullException(nameof(encoding));

			if(!encoding.GetPreamble().Any()) // UTF7Encoding should have an empty preamble.
				return encoding;

			if(encoding is UTF8Encoding utf8Encoding)
				return new UTF8Encoding(false, utf8Encoding.ThrowOnInvalidBytes());

			if(encoding is UTF32Encoding utf32Encoding)
				return new UTF32Encoding(utf32Encoding.BigEndian(), false, utf32Encoding.ThrowOnInvalidBytes());

			throw new InvalidOperationException($"Encoding of type {encoding.GetType()} not supported.");
		}

		#endregion
	}
}
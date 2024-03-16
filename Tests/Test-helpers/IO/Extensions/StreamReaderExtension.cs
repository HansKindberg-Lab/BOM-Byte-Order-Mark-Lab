using System.Reflection;
using Project.Extensions;

namespace TestHelpers.IO.Extensions
{
	public static class StreamReaderExtension
	{
		#region Fields

		private static readonly FieldInfo _byteLengthField = typeof(StreamReader).GetPrivateInstanceField(_byteLengthFieldName);
		private const string _byteLengthFieldName = "byteLen";
		private static readonly FieldInfo _bytePositionField = typeof(StreamReader).GetPrivateInstanceField(_bytePositionFieldName);
		private const string _bytePositionFieldName = "bytePos";
		private static readonly FieldInfo _characterLengthField = typeof(StreamReader).GetPrivateInstanceField(_characterLengthFieldName);
		private const string _characterLengthFieldName = "charLen";
		private static readonly FieldInfo _characterPositionField = typeof(StreamReader).GetPrivateInstanceField(_characterPositionFieldName);
		private const string _characterPositionFieldName = "charPos";

		#endregion

		#region Methods

		public static int ByteLength(this StreamReader streamReader)
		{
			if(streamReader == null)
				throw new ArgumentNullException(nameof(streamReader));

			if(_byteLengthField == null)
				throw new NullReferenceException($"The \"{_byteLengthFieldName}\" field could not be found for version \"{Environment.Version}\".");

			return (int)_byteLengthField.GetValue(streamReader);
		}

		public static int BytePosition(this StreamReader streamReader)
		{
			if(streamReader == null)
				throw new ArgumentNullException(nameof(streamReader));

			if(_bytePositionField == null)
				throw new NullReferenceException($"The \"{_bytePositionFieldName}\" field could not be found for version \"{Environment.Version}\".");

			return (int)_bytePositionField.GetValue(streamReader);
		}

		public static int CharacterLength(this StreamReader streamReader)
		{
			if(streamReader == null)
				throw new ArgumentNullException(nameof(streamReader));

			if(_characterLengthField == null)
				throw new NullReferenceException($"The \"{_characterLengthFieldName}\" field could not be found for version \"{Environment.Version}\".");

			return (int)_characterLengthField.GetValue(streamReader);
		}

		public static int CharacterPosition(this StreamReader streamReader)
		{
			if(streamReader == null)
				throw new ArgumentNullException(nameof(streamReader));

			if(_characterPositionField == null)
				throw new NullReferenceException($"The \"{_characterPositionFieldName}\" field could not be found for version \"{Environment.Version}\".");

			return (int)_characterPositionField.GetValue(streamReader);
		}

		#endregion
	}
}
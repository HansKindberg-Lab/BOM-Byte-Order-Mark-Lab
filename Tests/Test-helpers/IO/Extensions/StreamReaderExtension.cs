using System.Reflection;

namespace TestHelpers.IO.Extensions
{
	public static class StreamReaderExtension
	{
		#region Fields

		private static readonly FieldInfo _streamReaderByteLengthField = typeof(StreamReader).GetField("_byteLen", BindingFlags.Instance | BindingFlags.NonPublic)!;
		private static readonly FieldInfo _streamReaderBytePositionField = typeof(StreamReader).GetField("_bytePos", BindingFlags.Instance | BindingFlags.NonPublic)!;
		private static readonly FieldInfo _streamReaderCharacterLengthField = typeof(StreamReader).GetField("_charLen", BindingFlags.Instance | BindingFlags.NonPublic)!;
		private static readonly FieldInfo _streamReaderCharacterPositionField = typeof(StreamReader).GetField("_charPos", BindingFlags.Instance | BindingFlags.NonPublic)!;

		#endregion

		#region Methods

		public static int ByteLength(this StreamReader streamReader)
		{
			return (int)_streamReaderByteLengthField.GetValue(streamReader);
		}

		public static int BytePosition(this StreamReader streamReader)
		{
			return (int)_streamReaderBytePositionField.GetValue(streamReader);
		}

		public static int CharacterLength(this StreamReader streamReader)
		{
			return (int)_streamReaderCharacterLengthField.GetValue(streamReader);
		}

		public static int CharacterPosition(this StreamReader streamReader)
		{
			return (int)_streamReaderCharacterPositionField.GetValue(streamReader);
		}

		#endregion
	}
}
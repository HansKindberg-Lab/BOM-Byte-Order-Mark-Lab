using System.Text;

namespace UnitTests
{
	public class EncodingTest
	{
		#region Methods

		[Fact]
		public async Task Utf8Encoding_Preamble_IfEncoderShouldEmitUtf8IdentifierIsFalse_ShouldReturnASpanOfZero()
		{
			await Task.CompletedTask;

			var encoding = new UTF8Encoding(false);

			Assert.Equal(0, encoding.Preamble.Length);
		}

		[Fact]
		public async Task Utf8Encoding_Preamble_IfEncoderShouldEmitUtf8IdentifierIsTrue_ShouldReturnASpanOfThree()
		{
			await Task.CompletedTask;

			var encoding = new UTF8Encoding(true);

			Assert.Equal(3, encoding.Preamble.Length);
		}

		#endregion
	}
}
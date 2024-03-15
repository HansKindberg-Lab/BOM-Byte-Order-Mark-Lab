using System.Text;

namespace PrerequisiteTests.Text
{
	public class EncodingTest
	{
		#region Methods

		[Fact]
		public async Task Utf8Encoding_GetPreamble_IfEncoderShouldEmitUtf8IdentifierIsFalse_ShouldReturnASpanOfZero()
		{
			await Task.CompletedTask;

			var encoding = new UTF8Encoding(false);

			Assert.Empty(encoding.GetPreamble());
		}

		[Fact]
		public async Task Utf8Encoding_GetPreamble_IfEncoderShouldEmitUtf8IdentifierIsTrue_ShouldReturnASpanOfThree()
		{
			await Task.CompletedTask;

			var encoding = new UTF8Encoding(true);

			Assert.Equal(3, encoding.GetPreamble().Length);
		}

		#endregion
	}
}
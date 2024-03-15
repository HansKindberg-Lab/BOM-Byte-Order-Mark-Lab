using System.Text;
using Project.Text.Extensions;

namespace IntegrationTests.Text.Extensions
{
	public class EncodingExtensionTest
	{
		#region Methods

		[Fact]
		public async Task WithoutPreamble_IfUtf32Encoding_Test()
		{
			await Task.CompletedTask;

			var utf32Encoding = new UTF32Encoding(true, false, true);
			Assert.Empty(utf32Encoding.GetPreamble());
			Assert.Same(utf32Encoding, utf32Encoding.WithoutPreamble());
			Assert.Empty(utf32Encoding.WithoutPreamble().GetPreamble());

			utf32Encoding = new UTF32Encoding(true, true, true);
			Assert.Equal(4, utf32Encoding.GetPreamble().Length);
			Assert.NotSame(utf32Encoding, utf32Encoding.WithoutPreamble());
			Assert.Empty(utf32Encoding.WithoutPreamble().GetPreamble());
		}

		[Fact]
		public async Task WithoutPreamble_IfUtf8Encoding_Test()
		{
			await Task.CompletedTask;

			var utf8Encoding = new UTF8Encoding(false);
			Assert.Empty(utf8Encoding.GetPreamble());
			Assert.Same(utf8Encoding, utf8Encoding.WithoutPreamble());
			Assert.Empty(utf8Encoding.WithoutPreamble().GetPreamble());

			utf8Encoding = new UTF8Encoding(true);
			Assert.Equal(3, utf8Encoding.GetPreamble().Length);
			Assert.NotSame(utf8Encoding, utf8Encoding.WithoutPreamble());
			Assert.Empty(utf8Encoding.WithoutPreamble().GetPreamble());
		}

		#endregion
	}
}
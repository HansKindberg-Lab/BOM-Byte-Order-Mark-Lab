using System.Text;
using Project.Text.Extensions;

namespace IntegrationTests.Text.Extensions
{
	public class EncodingExtensionTest
	{
		#region Methods

		[Fact]
		public async Task WithoutByteOrderMark_IfAsciiEncoding_Test()
		{
			await Task.CompletedTask;

			var asciiEncoding = new ASCIIEncoding();
			Assert.Empty(asciiEncoding.GetPreamble());
			Assert.Same(asciiEncoding, asciiEncoding.WithoutByteOrderMark());
			Assert.Empty(asciiEncoding.WithoutByteOrderMark().GetPreamble());
		}

		[Fact]
		public async Task WithoutByteOrderMark_IfUnicodeEncoding_Test()
		{
			await Task.CompletedTask;

			var unicodeEncoding = new UnicodeEncoding(true, false, true);
			Assert.Empty(unicodeEncoding.GetPreamble());
			Assert.Same(unicodeEncoding, unicodeEncoding.WithoutByteOrderMark());
			Assert.Empty(unicodeEncoding.WithoutByteOrderMark().GetPreamble());

			unicodeEncoding = new UnicodeEncoding(true, true, true);
			Assert.Equal(2, unicodeEncoding.GetPreamble().Length);
			Assert.NotSame(unicodeEncoding, unicodeEncoding.WithoutByteOrderMark());
			Assert.Empty(unicodeEncoding.WithoutByteOrderMark().GetPreamble());
		}

		[Fact]
		public async Task WithoutByteOrderMark_IfUtf32Encoding_Test()
		{
			await Task.CompletedTask;

			var utf32Encoding = new UTF32Encoding(true, false, true);
			Assert.Empty(utf32Encoding.GetPreamble());
			Assert.Same(utf32Encoding, utf32Encoding.WithoutByteOrderMark());
			Assert.Empty(utf32Encoding.WithoutByteOrderMark().GetPreamble());

			utf32Encoding = new UTF32Encoding(true, true, true);
			Assert.Equal(4, utf32Encoding.GetPreamble().Length);
			Assert.NotSame(utf32Encoding, utf32Encoding.WithoutByteOrderMark());
			Assert.Empty(utf32Encoding.WithoutByteOrderMark().GetPreamble());
		}

		[Fact]
		public async Task WithoutByteOrderMark_IfUtf7Encoding_Test()
		{
			await Task.CompletedTask;

			var utf7Encoding = new UTF7Encoding();
			Assert.Empty(utf7Encoding.GetPreamble());
			Assert.Same(utf7Encoding, utf7Encoding.WithoutByteOrderMark());
			Assert.Empty(utf7Encoding.WithoutByteOrderMark().GetPreamble());

			utf7Encoding = new UTF7Encoding(false);
			Assert.Empty(utf7Encoding.GetPreamble());
			Assert.Same(utf7Encoding, utf7Encoding.WithoutByteOrderMark());
			Assert.Empty(utf7Encoding.WithoutByteOrderMark().GetPreamble());

			utf7Encoding = new UTF7Encoding(true);
			Assert.Empty(utf7Encoding.GetPreamble());
			Assert.Same(utf7Encoding, utf7Encoding.WithoutByteOrderMark());
			Assert.Empty(utf7Encoding.WithoutByteOrderMark().GetPreamble());
		}

		[Fact]
		public async Task WithoutByteOrderMark_IfUtf8Encoding_Test()
		{
			await Task.CompletedTask;

			var utf8Encoding = new UTF8Encoding(false);
			Assert.Empty(utf8Encoding.GetPreamble());
			Assert.Same(utf8Encoding, utf8Encoding.WithoutByteOrderMark());
			Assert.Empty(utf8Encoding.WithoutByteOrderMark().GetPreamble());

			utf8Encoding = new UTF8Encoding(true);
			Assert.Equal(3, utf8Encoding.GetPreamble().Length);
			Assert.NotSame(utf8Encoding, utf8Encoding.WithoutByteOrderMark());
			Assert.Empty(utf8Encoding.WithoutByteOrderMark().GetPreamble());
		}

		#endregion
	}
}
using System.Text;
using Project.Text.Extensions;

namespace PrerequisiteTests.Text
{
	public class UnicodeEncodingTest
	{
		#region Methods

		[Fact]
		public async Task Default_Constructor_BigEndian_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(new UnicodeEncoding().BigEndian());
		}

		[Fact]
		public async Task Default_Constructor_GetPreamble_ShouldReturnFourItems()
		{
			await Task.CompletedTask;

			var preamble = new UnicodeEncoding().GetPreamble();

			Assert.Equal(2, preamble.Length);
			Assert.Equal(255, preamble[0]);
			Assert.Equal(254, preamble[1]);
		}

		[Fact]
		public async Task Default_Constructor_ThrowOnInvalidBytes_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(new UnicodeEncoding().ThrowOnInvalidBytes());
		}

		[Fact]
		public async Task Encoding_Unicode_BigEndian_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(((UnicodeEncoding)Encoding.Unicode).BigEndian());
		}

		[Fact]
		public async Task Encoding_Unicode_GetPreamble_ShouldReturnFourItems()
		{
			await Task.CompletedTask;

			var preamble = Encoding.Unicode.GetPreamble();

			Assert.Equal(2, preamble.Length);
		}

		[Fact]
		public async Task Encoding_Unicode_ThrowOnInvalidBytes_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(((UnicodeEncoding)Encoding.Unicode).ThrowOnInvalidBytes());
		}

		#endregion
	}
}
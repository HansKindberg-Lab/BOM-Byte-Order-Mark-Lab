using System.Text;
using Project.Text.Extensions;

namespace PrerequisiteTests.Text
{
	public class Utf32EncodingTest
	{
		#region Methods

		[Fact]
		public async Task Default_Constructor_BigEndian_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(new UTF32Encoding().BigEndian());
		}

		[Fact]
		public async Task Default_Constructor_GetPreamble_ShouldReturnFourItems()
		{
			await Task.CompletedTask;

			var preamble = new UTF32Encoding().GetPreamble();

			Assert.Equal(4, preamble.Length);
			Assert.Equal(255, preamble[0]);
			Assert.Equal(254, preamble[1]);
			Assert.Equal(0, preamble[2]);
			Assert.Equal(0, preamble[3]);
		}

		[Fact]
		public async Task Default_Constructor_ThrowOnInvalidBytes_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(new UTF32Encoding().ThrowOnInvalidBytes());
		}

		[Fact]
		public async Task Encoding_UTF32_BigEndian_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(((UTF32Encoding)Encoding.UTF32).BigEndian());
		}

		[Fact]
		public async Task Encoding_UTF32_GetPreamble_ShouldReturnFourItems()
		{
			await Task.CompletedTask;

			var preamble = Encoding.UTF32.GetPreamble();

			Assert.Equal(4, preamble.Length);
			Assert.Equal(255, preamble[0]);
			Assert.Equal(254, preamble[1]);
			Assert.Equal(0, preamble[2]);
			Assert.Equal(0, preamble[3]);
		}

		[Fact]
		public async Task Encoding_UTF32_ThrowOnInvalidBytes_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(((UTF32Encoding)Encoding.UTF32).ThrowOnInvalidBytes());
		}

		#endregion
	}
}
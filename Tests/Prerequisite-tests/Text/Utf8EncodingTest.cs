using System.Text;
using Project.Text.Extensions;

namespace PrerequisiteTests.Text
{
	public class Utf8EncodingTest
	{
		#region Methods

		[Fact]
		public async Task Default_Constructor_GetPreamble_ShouldReturnAnEmptyArray()
		{
			await Task.CompletedTask;

			var preamble = new UTF8Encoding().GetPreamble();

			Assert.Empty(preamble);
		}

		[Fact]
		public async Task Default_Constructor_ThrowOnInvalidBytes_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(new UTF8Encoding().ThrowOnInvalidBytes());
		}

		[Fact]
		public async Task Encoding_UTF8_GetPreamble_ShouldReturnThreeItems()
		{
			await Task.CompletedTask;

			var preamble = Encoding.UTF8.GetPreamble();

			Assert.Equal(3, preamble.Length);
			Assert.Equal(239, preamble[0]);
			Assert.Equal(187, preamble[1]);
			Assert.Equal(191, preamble[2]);
		}

		[Fact]
		public async Task Encoding_UTF8_ThrowOnInvalidBytes_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			Assert.False(((UTF8Encoding)Encoding.UTF8).ThrowOnInvalidBytes());
		}

		#endregion
	}
}
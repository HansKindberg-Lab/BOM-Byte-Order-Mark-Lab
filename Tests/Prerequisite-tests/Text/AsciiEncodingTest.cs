using System.Text;

namespace PrerequisiteTests.Text
{
	public class AsciiEncodingTest
	{
		#region Methods

		[Fact]
		public async Task Default_Constructor_GetPreamble_ShouldReturnAnEmptyArray()
		{
			await Task.CompletedTask;

			Assert.Empty(new ASCIIEncoding().GetPreamble());
		}

		[Fact]
		public async Task Encoding_ASCII_GetPreamble_ShouldReturnAnEmptyArray()
		{
			await Task.CompletedTask;

			Assert.Empty(Encoding.ASCII.GetPreamble());
		}

		#endregion
	}
}
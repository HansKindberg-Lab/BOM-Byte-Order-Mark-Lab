using System.Text;

namespace PrerequisiteTests.Text
{
	public class Utf7EncodingTest
	{
		#region Methods

		[Fact]
		public async Task GetPreamble_ShouldReturnAnEmptyArray()
		{
			await Task.CompletedTask;

			Assert.Empty(new UTF7Encoding().GetPreamble());
			Assert.Empty(new UTF7Encoding(false).GetPreamble());
			Assert.Empty(new UTF7Encoding(true).GetPreamble());
		}

		#endregion
	}
}
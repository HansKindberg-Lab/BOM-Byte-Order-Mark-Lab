using Project.IO.Extensions;

namespace IntegrationTests.IO.Extensions
{
	public class StreamReaderExtensionTest
	{
		#region Methods

		private static string GetBomFilePath(string fileName)
		{
			return Path.Combine(Global.ProjectDirectory.FullName, "Resources", "BOM", fileName);
		}

		private static string GetNoBomFilePath(string fileName)
		{
			return Path.Combine(Global.ProjectDirectory.FullName, "Resources", "No-BOM", fileName);
		}

		[Fact]
		public async Task HasByteOrderMark_IfTheStreamReaderFileHasABom_ShouldReturnTrue()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetBomFilePath("bom.json")))
			{
				Assert.True(streamReader.HasByteOrderMark());
			}
		}

		[Fact]
		public async Task HasByteOrderMark_IfTheStreamReaderFileNotHasABom_ShouldReturnFalse()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetNoBomFilePath("no-bom.json")))
			{
				Assert.False(streamReader.HasByteOrderMark());
			}
		}

		#endregion
	}
}
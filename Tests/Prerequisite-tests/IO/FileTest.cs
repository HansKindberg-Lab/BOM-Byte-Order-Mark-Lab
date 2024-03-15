namespace PrerequisiteTests.IO
{
	public class Test
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
		public async Task ReadAllBytesAsync_BomJson_Bytes_Length_Test()
		{
			await Task.CompletedTask;

			var bytes = File.ReadAllBytes(GetBomFilePath("bom.json"));
			Assert.Equal(5, bytes.Length);
		}

		[Fact]
		public async Task ReadAllBytesAsync_NoBomJson_Bytes_Length_Test()
		{
			await Task.CompletedTask;

			var bytes = File.ReadAllBytes(GetNoBomFilePath("no-bom.json"));
			Assert.Equal(2, bytes.Length);
		}

		[Fact]
		public async Task ReadAllTextAsync_BomJson_Content_Length_Test()
		{
			await Task.CompletedTask;

			var content = File.ReadAllText(GetBomFilePath("bom.json"));
			Assert.Equal(2, content.Length);
		}

		[Fact]
		public async Task ReadAllTextAsync_NoBomJson_Content_Length_Test()
		{
			await Task.CompletedTask;

			var content = File.ReadAllText(GetNoBomFilePath("no-bom.json"));
			Assert.Equal(2, content.Length);
		}

		#endregion
	}
}
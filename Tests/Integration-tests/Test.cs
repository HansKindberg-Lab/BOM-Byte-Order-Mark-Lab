using System.Text;

namespace IntegrationTests
{
	public class Test
	{
		#region Methods

		[Fact]
		public async Task BomJson_Bytes_Length_Test()
		{
			var bytes = await File.ReadAllBytesAsync(GetBomFilePath("bom.json"));
			Assert.Equal(5, bytes.Length);
		}

		[Fact]
		public async Task BomJson_Content_Length_Test()
		{
			var content = await File.ReadAllTextAsync(GetBomFilePath("bom.json"));
			Assert.Equal(2, content.Length);
		}

		[Fact]
		public async Task BomJson_StreamReader_CurrentEncoding_IfDetectEncodingFromByteOrderMarksIsFalse_ShouldReturnUtf8()
		{
			await Task.CompletedTask;

			var path = GetBomFilePath("bom.json");

			using(var stream = File.OpenRead(path))
			{
				using(var streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks: false))
				{
					Assert.Equal(Encoding.UTF8, streamReader.CurrentEncoding);
				}
			}
		}

		[Fact]
		public async Task BomJson_StreamReader_CurrentEncoding_IfDetectEncodingFromByteOrderMarksIsTrue_ShouldReturnUtf8()
		{
			await Task.CompletedTask;

			var path = GetBomFilePath("bom.json");

			using(var stream = File.OpenRead(path))
			{
				using(var streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true))
				{
					Assert.Equal(Encoding.UTF8, streamReader.CurrentEncoding);
				}
			}
		}

		[Fact]
		public async Task BomJson_StreamReader_DetectEncodingFromByteOrderMarksIsTrue_Test()
		{
			await Task.CompletedTask;

			var path = GetBomFilePath("bom.json");

			using(var stream = File.OpenRead(path))
			{
				using(var streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true))
				{
					Assert.Equal(5, streamReader.BaseStream.Length);
					Assert.Equal(123, streamReader.Read());
					Assert.Equal(125, streamReader.Read());
					Assert.Equal(-1, streamReader.Read());
					Assert.True(streamReader.EndOfStream);
				}
			}
		}

		private static string GetBomFilePath(string fileName)
		{
			return Path.Combine(Global.ProjectDirectory.FullName, "Resources", "BOM", fileName);
		}

		private static string GetNoBomFilePath(string fileName)
		{
			return Path.Combine(Global.ProjectDirectory.FullName, "Resources", "No-BOM", fileName);
		}

		[Fact]
		public async Task NoBomJson_Bytes_Length_Test()
		{
			var bytes = await File.ReadAllBytesAsync(GetNoBomFilePath("no-bom.json"));
			Assert.Equal(2, bytes.Length);
		}

		[Fact]
		public async Task NoBomJson_Content_Length_Test()
		{
			var content = await File.ReadAllTextAsync(GetNoBomFilePath("no-bom.json"));
			Assert.Equal(2, content.Length);
		}

		[Fact]
		public async Task NoBomJson_StreamReader_CurrentEncoding_IfDetectEncodingFromByteOrderMarksIsFalse_ShouldReturnUtf8()
		{
			await Task.CompletedTask;

			var path = GetNoBomFilePath("no-bom.json");

			using(var stream = File.OpenRead(path))
			{
				using(var streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks: false))
				{
					Assert.Equal(Encoding.UTF8, streamReader.CurrentEncoding);
				}
			}
		}

		[Fact]
		public async Task NoBomJson_StreamReader_CurrentEncoding_IfDetectEncodingFromByteOrderMarksIsTrue_ShouldReturnUtf8()
		{
			await Task.CompletedTask;

			var path = GetNoBomFilePath("no-bom.json");

			using(var stream = File.OpenRead(path))
			{
				using(var streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true))
				{
					Assert.Equal(Encoding.UTF8, streamReader.CurrentEncoding);
				}
			}
		}

		[Fact]
		public async Task NoBomJson_StreamReader_DetectEncodingFromByteOrderMarksIsTrue_Test()
		{
			await Task.CompletedTask;

			var path = GetNoBomFilePath("no-bom.json");

			using(var stream = File.OpenRead(path))
			{
				using(var streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true))
				{
					Assert.Equal(2, streamReader.BaseStream.Length);
					Assert.Equal(123, streamReader.Read());
					Assert.Equal(125, streamReader.Read());
					Assert.Equal(-1, streamReader.Read());
					Assert.True(streamReader.EndOfStream);
				}
			}
		}

		#endregion
	}
}
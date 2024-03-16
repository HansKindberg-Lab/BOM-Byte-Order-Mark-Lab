using System.Text;
using TestHelpers.IO.Extensions;

namespace PrerequisiteTests.IO
{
	public class StreamReaderTest
	{
		#region Methods

		[Fact]
		public async Task BaseStream_BomJson_IfDetectEncodingFromByteOrderMarksIsTrueInConstructor_Test()
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

		[Fact]
		public async Task BaseStream_IfBomFile_And_IfDetectEncodingFromByteOrderMarks_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetBomFilePath("bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				Assert.Equal(5, streamReader.BaseStream.Length);
			}
		}

		[Fact]
		public async Task BaseStream_IfNoBomFile_And_IfDetectEncodingFromByteOrderMarks_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetNoBomFilePath("no-bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				Assert.Equal(2, streamReader.BaseStream.Length);
			}
		}

		[Fact]
		public async Task BaseStream_NoBomJson_IfDetectEncodingFromByteOrderMarksIsTrueInConstructor_Test()
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

		[Fact]
		public async Task CurrentEncoding_BomJson_IfDetectEncodingFromByteOrderMarksIsFalseInConstructor_ShouldReturnUtf8()
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
		public async Task CurrentEncoding_BomJson_IfDetectEncodingFromByteOrderMarksIsTrueInConstructor_ShouldReturnUtf8()
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
		public async Task CurrentEncoding_NoBomJson_IfDetectEncodingFromByteOrderMarksIsFalseInConstructor_ShouldReturnUtf8()
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
		public async Task CurrentEncoding_NoBomJson_IfDetectEncodingFromByteOrderMarksIsTrueInConstructor_ShouldReturnUtf8()
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
		public async Task CurrentEncoding_Preamble_IfBomFile_And_IfDetectEncodingFromByteOrderMarks_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetBomFilePath("bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				Assert.Equal(3, streamReader.CurrentEncoding.GetPreamble().Length);
			}
		}

		[Fact]
		public async Task CurrentEncoding_Preamble_IfNoBomFile_And_IfDetectEncodingFromByteOrderMarks_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetNoBomFilePath("no-bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				Assert.Equal(3, streamReader.CurrentEncoding.GetPreamble().Length);
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
		public async Task InternalFields_IfBomFile_And_IfDetectEncodingFromByteOrderMarks_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetBomFilePath("bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				var byteLength = streamReader.ByteLength();
				var bytePosition = streamReader.BytePosition();
				var characterLength = streamReader.CharacterLength();
				var characterPosition = streamReader.CharacterPosition();

				Assert.Equal(0, byteLength);
				Assert.Equal(0, bytePosition);
				Assert.Equal(0, characterLength);
				Assert.Equal(0, characterPosition);

				streamReader.Peek();

				byteLength = streamReader.ByteLength();
				bytePosition = streamReader.BytePosition();
				characterLength = streamReader.CharacterLength();
				characterPosition = streamReader.CharacterPosition();

				Assert.Equal(2, byteLength);
				Assert.Equal(0, bytePosition);
				Assert.Equal(2, characterLength);
				Assert.Equal(0, characterPosition);
			}
		}

		[Fact]
		public async Task InternalFields_IfNoBomFile_And_IfDetectEncodingFromByteOrderMarks_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetNoBomFilePath("no-bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				var byteLength = streamReader.ByteLength();
				var bytePosition = streamReader.BytePosition();
				var characterLength = streamReader.CharacterLength();
				var characterPosition = streamReader.CharacterPosition();

				Assert.Equal(0, byteLength);
				Assert.Equal(0, bytePosition);
				Assert.Equal(0, characterLength);
				Assert.Equal(0, characterPosition);

				streamReader.Peek();

				byteLength = streamReader.ByteLength();
				bytePosition = streamReader.BytePosition();
				characterLength = streamReader.CharacterLength();
				characterPosition = streamReader.CharacterPosition();

				Assert.Equal(2, byteLength);
				Assert.Equal(0, bytePosition);
				Assert.Equal(2, characterLength);
				Assert.Equal(0, characterPosition);
			}
		}

		#endregion
	}
}
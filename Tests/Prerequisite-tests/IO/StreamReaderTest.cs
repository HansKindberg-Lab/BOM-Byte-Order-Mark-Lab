using System.Text;
using Project.IO.Extensions;
using TestHelpers.IO.Extensions;

namespace PrerequisiteTests.IO
{
	public class StreamReaderTest
	{
		#region Methods

		[Fact]
		public async Task BaseStream_BomJson_IfDetectEncodingFromByteOrderMarksIsTrue_Test()
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
		public async Task BaseStream_IfBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetBomFilePath("bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				Assert.Equal(5, streamReader.BaseStream.Length);
			}
		}

		[Fact]
		public async Task BaseStream_IfNoBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetNoBomFilePath("no-bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				Assert.Equal(2, streamReader.BaseStream.Length);
			}
		}

		[Fact]
		public async Task BaseStream_NoBomJson_IfDetectEncodingFromByteOrderMarksIsTrue_Test()
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
		public async Task CurrentEncoding_BomJson_IfDetectEncodingFromByteOrderMarksIsFalse_ShouldReturnUtf8()
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
		public async Task CurrentEncoding_BomJson_IfDetectEncodingFromByteOrderMarksIsTrue_ShouldReturnUtf8()
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
		public async Task CurrentEncoding_NoBomJson_IfDetectEncodingFromByteOrderMarksIsFalse_ShouldReturnUtf8()
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
		public async Task CurrentEncoding_NoBomJson_IfDetectEncodingFromByteOrderMarksIsTrue_ShouldReturnUtf8()
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
		public async Task CurrentEncoding_Preamble_IfBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_Test()
		{
			await Task.CompletedTask;

			using(var streamReader = new StreamReader(GetBomFilePath("bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				Assert.Equal(3, streamReader.CurrentEncoding.GetPreamble().Length);
			}
		}

		[Fact]
		public async Task CurrentEncoding_Preamble_IfNoBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_Test()
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

		private static string GetOutputFilePath(string fileName)
		{
			return Path.Combine(Global.OutputDirectory.FullName, fileName);
		}

		[Fact]
		public async Task InternalFields_IfBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_Test()
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
		public async Task InternalFields_IfNoBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_Test()
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

		[Fact]
		public async Task ReadToEnd_AndWriteToFile_IfBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_ShouldCreateAFileWithByteOrderMark()
		{
			await Task.CompletedTask;

			var outputFilePath = GetOutputFilePath($"{Guid.NewGuid()}.json");

			using(var streamReader = new StreamReader(GetBomFilePath("bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				// ReSharper disable MethodHasAsyncOverload

				var content = streamReader.ReadToEnd();

				Directory.CreateDirectory(new FileInfo(outputFilePath).Directory!.FullName);

				File.WriteAllText(outputFilePath, content, streamReader.CurrentEncoding);

				// ReSharper restore MethodHasAsyncOverload
			}

			using(var streamReader = new StreamReader(outputFilePath, detectEncodingFromByteOrderMarks: true))
			{
				Assert.True(streamReader.HasByteOrderMark());
			}
		}

		/// <summary>
		/// This is why we have to do something. If the source-file has no BOM I would like the written file to have no BOM also.
		/// </summary>
		[Fact]
		public async Task ReadToEnd_AndWriteToFile_IfNoBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_ShouldCreateAFileWithByteOrderMark()
		{
			await Task.CompletedTask;

			var outputFilePath = GetOutputFilePath($"{Guid.NewGuid()}.json");

			using(var streamReader = new StreamReader(GetNoBomFilePath("no-bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				// ReSharper disable MethodHasAsyncOverload

				var content = streamReader.ReadToEnd();

				Directory.CreateDirectory(new FileInfo(outputFilePath).Directory!.FullName);

				File.WriteAllText(outputFilePath, content, streamReader.CurrentEncoding);

				// ReSharper restore MethodHasAsyncOverload
			}

			using(var streamReader = new StreamReader(outputFilePath, detectEncodingFromByteOrderMarks: true))
			{
				Assert.True(streamReader.HasByteOrderMark());
			}
		}

#if NETCOREAPP3_1_OR_GREATER
		[Fact]
		public async Task ReadToEndAsync_AndWriteToFileAsync_IfBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_ShouldCreateAFileWithByteOrderMark()
		{
			var outputFilePath = GetOutputFilePath($"{Guid.NewGuid()}.json");

			using(var streamReader = new StreamReader(GetBomFilePath("bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				var content = await streamReader.ReadToEndAsync();

				Directory.CreateDirectory(new FileInfo(outputFilePath).Directory!.FullName);

				await File.WriteAllTextAsync(outputFilePath, content, streamReader.CurrentEncoding);
			}

			using(var streamReader = new StreamReader(outputFilePath, detectEncodingFromByteOrderMarks: true))
			{
				Assert.True(streamReader.HasByteOrderMark());
			}
		}
#endif
#if NETCOREAPP3_1_OR_GREATER
		/// <summary>
		/// This is why we have to do something. If the source-file has no BOM I would like the written file to have no BOM also.
		/// </summary>
		[Fact]
		public async Task ReadToEndAsync_AndWriteToFileAsync_IfNoBomFile_And_IfDetectEncodingFromByteOrderMarksIsTrue_ShouldCreateAFileWithByteOrderMark()
		{
			var outputFilePath = GetOutputFilePath($"{Guid.NewGuid()}.json");

			using(var streamReader = new StreamReader(GetNoBomFilePath("no-bom.json"), detectEncodingFromByteOrderMarks: true))
			{
				var content = await streamReader.ReadToEndAsync();

				Directory.CreateDirectory(new FileInfo(outputFilePath).Directory!.FullName);

				await File.WriteAllTextAsync(outputFilePath, content, streamReader.CurrentEncoding);
			}

			using(var streamReader = new StreamReader(outputFilePath, detectEncodingFromByteOrderMarks: true))
			{
				Assert.True(streamReader.HasByteOrderMark());
			}
		}
#endif

		#endregion
	}
}
namespace PrerequisiteTests.IO
{
	public class StreamTest
	{
		#region Methods

		[Fact]
		public async Task CopyTo_ForwardsThePosition()
		{
			await Task.CompletedTask;

			using(var stream = new MemoryStream([1, 2, 3, 4, 5]))
			{
				Assert.Equal(0, stream.Position);

				using(var memoryStream = new MemoryStream())
				{
					// ReSharper disable MethodHasAsyncOverload
					stream.CopyTo(memoryStream);
					// ReSharper restore MethodHasAsyncOverload
					Assert.Equal(5, memoryStream.ToArray().Length);
				}

				Assert.Equal(5, stream.Position);
			}
		}

		[Fact]
		public async Task CopyToAsync_ForwardsThePosition()
		{
			using(var stream = new MemoryStream([1, 2, 3, 4, 5]))
			{
				Assert.Equal(0, stream.Position);

				using(var memoryStream = new MemoryStream())
				{
					await stream.CopyToAsync(memoryStream);
					Assert.Equal(5, memoryStream.ToArray().Length);
				}

				Assert.Equal(5, stream.Position);
			}
		}

		#endregion
	}
}
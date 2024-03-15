namespace PrerequisiteTests.IO
{
	public class MemoryStreamTest
	{
		#region Methods

		[Fact]
		public async Task ToArray_ShouldNotForwardThePosition()
		{
			await Task.CompletedTask;

			using(var memoryStream = new MemoryStream([1, 2, 3, 4, 5]))
			{
				Assert.Equal(0, memoryStream.Position);
				_ = memoryStream.ToArray();
				Assert.Equal(0, memoryStream.Position);
			}
		}

		[Fact]
		public async Task ToArray_ShouldWorkMultipleTimes()
		{
			await Task.CompletedTask;

			using(var memoryStream = new MemoryStream([1, 2, 3, 4, 5]))
			{
				var first = memoryStream.ToArray();
				Assert.Equal(5, first.Length);
				Assert.Equal(1, first[0]);
				Assert.Equal(2, first[1]);
				Assert.Equal(3, first[2]);
				Assert.Equal(4, first[3]);
				Assert.Equal(5, first[4]);

				var second = memoryStream.ToArray();
				Assert.Equal(5, second.Length);
				Assert.Equal(1, second[0]);
				Assert.Equal(2, second[1]);
				Assert.Equal(3, second[2]);
				Assert.Equal(4, second[3]);
				Assert.Equal(5, second[4]);
			}
		}

		#endregion
	}
}
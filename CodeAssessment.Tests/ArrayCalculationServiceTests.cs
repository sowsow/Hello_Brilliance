namespace CodeAssessment.Tests
{
	using System;
	using System.Threading.Tasks;

	using CodeAssessment.Services;
	using CodeAssessment.Services.Interfaces;

	using FluentAssertions;

	using Xunit;

	public class ArrayCalculationServiceTests
	{
		private readonly IArrayCalculationService _arrayCalculationService;


		public ArrayCalculationServiceTests()
		{
			_arrayCalculationService = new ArrayCalculationService();
		}

		[Fact]
		public async Task WhenInputArrayIsNullThenReverseThrowsArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(
				async () => await _arrayCalculationService.Reverse(null));
		}

		[Fact]
		public async Task WhenInputArrayIsEmptyThenReverseThrowsInvalidOperationException()
		{
			var array = new int[0];

			await Assert.ThrowsAsync<InvalidOperationException>(
				async () => await _arrayCalculationService.Reverse(array));
		}

		[Fact]
		public async Task WhenInputArrayIsNullThenDeletePartialElementThrowsInvalidOperationException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(
				async () => await _arrayCalculationService.DeletePartialElement(0, null));
		}

		[Fact]
		public async Task WhenInputArrayIsEmptyThenDeletePartialElementThrowsInvalidOperationException()
		{
			var array = new int[0];

			await Assert.ThrowsAsync<InvalidOperationException>(
				async () => await _arrayCalculationService.DeletePartialElement(0, array));
		}

		[Theory]
		[InlineData(2, new [] { 1 })]
		[InlineData(0, new [] { 1 })]
		[InlineData(-1, new [] { 1 })]
		public async Task WhenInputPositionIsNotValidThenDeletePartialElementThrowsArgumentOutOfRangeException(int position, int[] array)
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
				async () => await _arrayCalculationService.DeletePartialElement(position, array));
		}

		[Theory]
		[InlineData(new [] { 1 }, new [] { 1 })]
		[InlineData(new [] { 1, 2, 3, 4, 5 }, new [] { 5, 4, 3, 2, 1 })]
		public async Task WhenInputArrayIsValidThenReverseResultIsCorrect(int[] input, int[] expect)
		{
			var actual = await _arrayCalculationService.Reverse(input);

			actual.Should().BeEquivalentTo(expect);
		}

		[Theory]
		[InlineData(1, new [] { 1 }, new int[] {})]
		[InlineData(1, new [] { 1, 2, 3, 4, 5 }, new [] { 2, 3, 4, 5 })]
		[InlineData(3, new [] { 1, 2, 3, 4, 5 }, new [] { 1, 2, 4, 5 })]
		[InlineData(5, new [] { 1, 2, 3, 4, 5 }, new [] { 1, 2, 3, 4 })]
		public async Task WhenInputPositionAndArrayAreValidThenDeletePartialElementResultIsCorrect(int position, int[] input, int[] expect)
		{
			var actual = await _arrayCalculationService.DeletePartialElement(position, input);

			actual.Should().BeEquivalentTo(expect);
		}
	}
}

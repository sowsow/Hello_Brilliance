namespace CodeAssessment.Tests
{
	using System.Threading.Tasks;

	using AutoFixture;

	using CodeAssessment.Controllers;
	using CodeAssessment.Services.Interfaces;

	using FluentAssertions;

	using Microsoft.AspNetCore.Mvc;

	using NSubstitute;

	using Xunit;

	public class ArrayCalculationControllerTests
	{
		private readonly ArrayCalculationController _arrayCalculationController;

		private readonly IFixture _fixture;

		private readonly IArrayCalculationService _arrayCalculationService;


		public ArrayCalculationControllerTests()
		{
			_fixture = new Fixture();

			_arrayCalculationService = Substitute.For<IArrayCalculationService>();

			_arrayCalculationController = new ArrayCalculationController(_arrayCalculationService);
		}

		[Fact]
		public async Task WhenArrayCalculationServiceReverseReturnsValueThenResultIsOk()
		{
			var array = new [] { 1 };

			_arrayCalculationService
				.Reverse(Arg.Any<int[]>())
				.Returns(array);

			var result = await _arrayCalculationController.Reverse(array);

			result.Result.Should().BeOfType<OkObjectResult>();
		}

		[Fact]
		public async Task WhenArrayCalculationServiceDeletePartialElementReturnsValueThenResultIsOk()
		{
			var array = new [] { 1 };

			_arrayCalculationService
				.DeletePartialElement(Arg.Any<int>(), Arg.Any<int[]>())
				.Returns(array);

			var result = await _arrayCalculationController.DeletePartialElement(0, null);

			result.Result.Should().BeOfType<OkObjectResult>();
		}
	}
}

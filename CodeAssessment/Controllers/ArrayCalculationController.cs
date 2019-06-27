namespace CodeAssessment.Controllers
{
	using System.Threading.Tasks;

	using CodeAssessment.Services.Interfaces;

	using Microsoft.AspNetCore.Mvc;

	[Route("api/arraycalc")]
	[Produces("application/json")]
	[ApiController]
	public class ArrayCalculationController : ControllerBase
	{
		private readonly IArrayCalculationService _arrayCalculationService;

		public ArrayCalculationController(IArrayCalculationService arrayCalculationService)
		{
			_arrayCalculationService = arrayCalculationService;
		}

		// GET api/arraycalc/reverse
		[HttpGet("reverse")]
		public async Task<ActionResult<int[]>> Reverse([FromQuery(Name = "productIds")] int[] productIds)
		{
			var result = await _arrayCalculationService.Reverse(productIds);

			return Ok(result);
		}

		// GET api/arraycalc/deletepart
		[HttpGet("deletepart")]
		public async Task<ActionResult<int[]>> DeletePartialElement(
			int position,
			[FromQuery(Name = "productIds")] int[] productIds)
		{
			var result = await _arrayCalculationService.DeletePartialElement(position, productIds);

			return Ok(result);
		}
	}
}
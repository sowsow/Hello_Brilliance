namespace CodeAssessment.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	[Route("")]
	[ApiController]
	public class HealthController
	{
		[HttpGet]
		public string HealthCheck()
		{
			return "Hello Brilliance.";
		}
	}
}

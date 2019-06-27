namespace CodeAssessment.Services
{
	using CodeAssessment.Services.Interfaces;

	using Microsoft.Extensions.DependencyInjection;

	public static class Configuration
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			return services
				.AddTransient<IArrayCalculationService, ArrayCalculationService>();
		}
	}
}

namespace CodeAssessment.Tests
{
	using System;
	using System.Linq;

	using FluentAssertions;

	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	using Xunit;

	public class HostTests
	{
		[Theory]
		[InlineData(typeof(Startup))]
		public void WhenServicesAreAddedThenAllTheInterfacesCanBeResolved(Type type)
		{
			var configuration = new ConfigurationBuilder().Build();
			var startup = new Startup(configuration);

			var services = new ServiceCollection();
			startup.ConfigureServices(services);

			var serviceProvider = services.BuildServiceProvider();

			var interfaces = type.Assembly.GetTypes().Where(c => c.IsInterface && c.IsPublic).ToArray();


			foreach (var @interface in interfaces)
			{
				serviceProvider
					.GetServices(@interface)
					.Should()
					.NotBeEmpty($"{@interface.Name} can't be resolved");
			}
		}
	}
}

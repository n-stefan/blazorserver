
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public abstract class BaseWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
  protected override IHost CreateHost(IHostBuilder builder)
  {
    var testHost = builder.Build();

    builder.ConfigureWebHost(webHostBuilder => webHostBuilder.UseKestrel());

    var host = builder.Build();
    host.Start();

    return testHost;
  }
}

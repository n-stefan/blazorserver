
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class GrpcUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    base.ConfigureWebHost(builder);

    ConfigureServices<GrpcCookieService>(builder);
  }
}

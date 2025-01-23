
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class GrpcJsonUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    base.ConfigureWebHost(builder);

    ConfigureServices<GrpcJsonCookieService>(builder, new Uri("https://localhost:5004"));
  }
}

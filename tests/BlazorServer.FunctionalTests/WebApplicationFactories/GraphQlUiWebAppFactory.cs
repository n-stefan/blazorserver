
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class GraphQlUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    base.ConfigureWebHost(builder);

    ConfigureServices<GraphQlCookieService>(builder, new Uri("http://localhost:5005"));
  }
}

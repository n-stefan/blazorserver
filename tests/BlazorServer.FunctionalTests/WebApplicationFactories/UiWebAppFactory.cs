
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class UiWebAppFactory : BaseWebAppFactory<WebUiMarker>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder) =>
    builder.UseUrls("https://localhost:5001");
}

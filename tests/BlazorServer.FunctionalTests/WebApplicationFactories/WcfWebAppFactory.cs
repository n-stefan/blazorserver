
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class WcfWebAppFactory : BaseWebAppFactory<WebApiWcfMarker>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder) =>
    builder.UseUrls("https://localhost:5008");
}

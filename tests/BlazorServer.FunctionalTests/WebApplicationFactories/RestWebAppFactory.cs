
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class RestWebAppFactory : BaseWebAppFactory<WebApiRestMarker>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder) =>
    builder.UseUrls("https://localhost:5003");
}

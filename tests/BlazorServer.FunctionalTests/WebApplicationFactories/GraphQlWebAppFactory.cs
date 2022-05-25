
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class GraphQlWebAppFactory : BaseWebAppFactory<WebApiGraphQlMarker>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder) =>
    builder.UseUrls("http://localhost:5005");
}

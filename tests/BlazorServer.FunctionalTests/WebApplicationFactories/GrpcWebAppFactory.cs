
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class GrpcWebAppFactory : BaseWebAppFactory<WebApiGrpcMarker>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder) =>
    builder.UseUrls("https://localhost:5004");
}

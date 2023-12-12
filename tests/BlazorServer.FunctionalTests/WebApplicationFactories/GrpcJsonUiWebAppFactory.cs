
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class GrpcJsonUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    base.ConfigureWebHost(builder);

    builder.ConfigureServices(services =>
    {
      var cookieService = services.Single(descriptor => descriptor.ServiceType == typeof(ICookieService));
      services.Remove(cookieService);
      services.AddHttpClient<ICookieService, GrpcJsonCookieService>(client => client.BaseAddress = new Uri("https://localhost:5004"));
    });
  }
}

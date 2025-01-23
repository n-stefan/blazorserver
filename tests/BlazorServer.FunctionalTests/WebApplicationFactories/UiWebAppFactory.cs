
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class UiWebAppFactory : BaseWebAppFactory<WebUiMarker>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder) =>
    builder.UseUrls("https://localhost:5001");

  protected static void ConfigureServices<T>(IWebHostBuilder builder) where T : class, ICookieService
  {
    builder.ConfigureServices(services =>
    {
      var cookieService = services.Single(descriptor => descriptor.ServiceType == typeof(ICookieService));
      services.Remove(cookieService);
      services.AddScoped<ICookieService, T>();
    });
  }

  protected static void ConfigureServices<T>(IWebHostBuilder builder, Uri uri) where T : class, ICookieService
  {
    builder.ConfigureServices(services =>
    {
      var cookieService = services.Single(descriptor => descriptor.ServiceType == typeof(ICookieService));
      services.Remove(cookieService);
      services.AddHttpClient<ICookieService, T>(client => client.BaseAddress = uri);
    });
  }
}

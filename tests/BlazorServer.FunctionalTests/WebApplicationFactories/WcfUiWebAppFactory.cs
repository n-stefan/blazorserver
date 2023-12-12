
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class WcfUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    base.ConfigureWebHost(builder);

    builder.ConfigureServices(services =>
    {
      var cookieService = services.Single(descriptor => descriptor.ServiceType == typeof(ICookieService));
      services.Remove(cookieService);
      services.AddScoped<ICookieService, WcfCookieService>();
    });
  }
}


namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public class RestUiWebAppFactory : UiWebAppFactory
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    base.ConfigureWebHost(builder);

    builder.ConfigureServices(services =>
    {
      var cookieService = services.Single(descriptor => descriptor.ServiceType == typeof(ICookieService));
      services.Remove(cookieService);
      services.AddHttpClient<ICookieService, RestCookieService>(client => client.BaseAddress = new Uri("https://localhost:5003"));
    });
  }
}

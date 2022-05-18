
namespace BlazorServer.FunctionalTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.UseUrls("https://localhost:5001");
  }

  protected override IHost CreateHost(IHostBuilder builder)
  {
    var testHost = builder.Build();

    builder.ConfigureWebHost(webHostBuilder => webHostBuilder.UseKestrel());

    var host = builder.Build();
    host.Start();

    return testHost;
  }
}

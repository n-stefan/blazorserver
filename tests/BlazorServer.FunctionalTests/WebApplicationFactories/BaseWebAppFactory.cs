
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public abstract class BaseWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
  private readonly IHost _fakeHost;

  protected BaseWebAppFactory()
  {
    _fakeHost = new HostBuilder()
      .ConfigureWebHost(x => x
        .UseTestServer()
        .UseStartup<FakeStartup>())
      .Build();
    _fakeHost.Start();
  }

  protected override IHost CreateHost(IHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.ConfigureWebHost(x => x.UseKestrelCore());
    builder.Build();

    return _fakeHost;
  }

  protected override void Dispose(bool disposing)
  {
    base.Dispose(disposing);
    _fakeHost.Dispose();
  }

  private sealed class FakeStartup
  {
    public static void Configure() { }
  }
}

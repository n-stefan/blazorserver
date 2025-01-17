
namespace BlazorServer.FunctionalTests.WebApplicationFactories;

public abstract class BaseWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
  private readonly IHost _fakeHost;

  protected BaseWebAppFactory()
  {
    var server = new TestServer(new WebHostBuilder().UseStartup<FakeStartup>());
#pragma warning disable EXTEXP0016
    _fakeHost = FakeHost.CreateBuilder().ConfigureServices(x => x.AddSingleton<IServer>(_ => server)).Build();
#pragma warning restore EXTEXP0016
  }

  protected override IHost CreateHost(IHostBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.ConfigureWebHost(x => x.UseKestrelCore());
    var host = builder.Build();
    host.Start();

    return _fakeHost;
  }

  protected override void Dispose(bool disposing)
  {
    base.Dispose(disposing);
    _fakeHost.Dispose();
  }

  private class FakeStartup
  {
    public void Configure() { }
  }
}

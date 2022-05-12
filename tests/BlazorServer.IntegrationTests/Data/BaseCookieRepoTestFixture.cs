
namespace BlazorServer.IntegrationTests.Data;

public abstract class BaseCookieRepoTestFixture
{
  protected AppDbContext _dbContext;

  protected BaseCookieRepoTestFixture()
  {
    var options = CreateNewContextOptions();

    _dbContext = new AppDbContext(options);
  }

  protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
  {
    var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

    var builder = new DbContextOptionsBuilder<AppDbContext>();
    builder.UseInMemoryDatabase("blazorserver")
           .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

  protected CookieRepository GetRepository() =>
    new(_dbContext);
}

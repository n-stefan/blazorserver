
namespace BlazorServer.IntegrationTests.Data;

public abstract class BaseCookieRepoTestFixture : IDisposable
{
  private readonly DbConnection _connection;
  private readonly DbContextOptions<AppDbContext> _contextOptions;

  protected BaseCookieRepoTestFixture()
  {
    _connection = new SqliteConnection("Filename=:memory:");
    _connection.Open();

    _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
      .UseSqlite(_connection)
      .Options;

    using var context = new AppDbContext(_contextOptions);

    context.Database.EnsureCreated();

    context.Cookies.AddRange(SeedData.Cookies.Select(c => new Cookie { Message = c }));
    context.SaveChanges();
  }

  protected CookieRepository GetRepository() =>
    new(new AppDbContext(_contextOptions));

  public void Dispose() =>
    _connection.Dispose();
}

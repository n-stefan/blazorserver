
namespace BlazorServer.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    optionsBuilder.UseSqlite($"Data Source={Path.Combine("..", "cookies.db")}");

    return new AppDbContext(optionsBuilder.Options);
  }
}

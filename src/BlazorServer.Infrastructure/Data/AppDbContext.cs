
namespace BlazorServer.Infrastructure.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
    ChangeTracker.AutoDetectChangesEnabled = false;
    ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
  }

  public DbSet<Cookie> Cookies { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Cookie>().HasData(
        new Cookie { Id = 1, Message = SeedData.Cookies[0] },
        new Cookie { Id = 2, Message = SeedData.Cookies[1] },
        new Cookie { Id = 3, Message = SeedData.Cookies[2] },
        new Cookie { Id = 4, Message = SeedData.Cookies[3] },
        new Cookie { Id = 5, Message = SeedData.Cookies[4] },
        new Cookie { Id = 6, Message = SeedData.Cookies[5] },
        new Cookie { Id = 7, Message = SeedData.Cookies[6] },
        new Cookie { Id = 8, Message = SeedData.Cookies[7] },
        new Cookie { Id = 9, Message = SeedData.Cookies[8] },
        new Cookie { Id = 10, Message = SeedData.Cookies[9] },
        new Cookie { Id = 11, Message = SeedData.Cookies[10] },
        new Cookie { Id = 12, Message = SeedData.Cookies[11] }
    );

    base.OnModelCreating(modelBuilder);
  }
}

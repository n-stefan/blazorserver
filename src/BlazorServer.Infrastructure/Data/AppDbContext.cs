
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
        new Cookie { Id = 1, Message = "fortune: No such file or directory" },
        new Cookie { Id = 2, Message = "A computer scientist is someone who fixes things that aren't broken." },
        new Cookie { Id = 3, Message = "After enough decimal places, nobody gives a damn." },
        new Cookie { Id = 4, Message = "A bad random number generator: 1, 1, 1, 1, 1, 4.33e+67, 1, 1, 1" },
        new Cookie { Id = 5, Message = "A computer program does what you tell it to do, not what you want it to do." },
        new Cookie { Id = 6, Message = "Emacs is a nice operating system, but I prefer UNIX. — Tom Christaensen" },
        new Cookie { Id = 7, Message = "Any program that runs right is obsolete." },
        new Cookie { Id = 8, Message = "A list is only as strong as its weakest link. — Donald Knuth" },
        new Cookie { Id = 9, Message = "Feature: A bug with seniority." },
        new Cookie { Id = 10, Message = "Computers make very fast, very accurate mistakes." },
        new Cookie { Id = 11, Message = "<script>alert('This should not be displayed in a browser alert box.');</script>" },
        new Cookie { Id = 12, Message = "フレームワークのベンチマーク" }
    );

    base.OnModelCreating(modelBuilder);
  }
}


namespace BlazorServer.Infrastructure.Data;

public abstract class EfRepository<TEntity, TContext>(TContext context) : IRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext
{
  private static readonly Func<TContext, IAsyncEnumerable<int>> _allIdsQuery =
      EF.CompileAsyncQuery((TContext context) => context.Set<TEntity>().Select(e => e.Id));

  private static readonly Func<TContext, int, Task<TEntity?>> _entityByIdQuery =
      EF.CompileAsyncQuery((TContext context, int id) => context.Set<TEntity>().SingleOrDefault(e => e.Id == id));

  public async Task<TEntity?> GetRandom()
  {
    var ids = new List<int>();
    await foreach (var id in _allIdsQuery(context))
    {
      ids.Add(id);
    }
    var index = Random.Shared.Next(0, ids.Count);
    return await _entityByIdQuery(context, ids[index]);
  }
}


namespace Data;

public class EfRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext
{
    private static readonly Func<TContext, IEnumerable<int>> _allIdsQuery =
        EF.CompileQuery((TContext context) => context.Set<TEntity>().Select(e => e.Id));

    private static readonly Func<TContext, int, Task<TEntity>> _entityByIdQuery =
        EF.CompileAsyncQuery((TContext context, int id) => context.Set<TEntity>().SingleOrDefault(e => e.Id == id));

    private readonly TContext _context;
    private readonly int[] _ids;

    public EfRepository(TContext context)
    {
        _context = context;
        // Assume no entities will be deleted / inserted
        _ids = _allIdsQuery(_context).ToArray();
    }

    public Task<TEntity> GetRandom()
    {
        var index = Random.Shared.Next(0, _ids.Length);
        return _entityByIdQuery(_context, _ids[index]);
    }
}

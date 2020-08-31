using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext
    {
        private static readonly Func<TContext, int> _countQuery = EF.CompileQuery((TContext context) =>
            context.Set<TEntity>().Count());

        private static readonly Func<TContext, int, Task<TEntity>> _singleQuery = EF.CompileAsyncQuery((TContext context, int id) =>
            context.Set<TEntity>().SingleOrDefault(e => e.Id == id));

        private readonly TContext _context;
        private readonly Random _random;

        public EfRepository(TContext context)
        {
            _context = context;
            _random = new Random();
        }

        public Task<TEntity> GetRandom()
        {
            var id = _random.Next(1, _countQuery(_context) + 1);
            return _singleQuery(_context, id);
        }
    }
}

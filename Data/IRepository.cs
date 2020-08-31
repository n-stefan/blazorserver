using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetRandom();
    }
}

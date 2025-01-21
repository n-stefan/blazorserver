
namespace BlazorServer.SharedKernel.Interfaces;

public interface IRepository<TEntity>
{
  Task<TEntity?> GetRandomAsync();
}

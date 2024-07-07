namespace CatchUpPlatformRi.API.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByAsync(int id);

    void Update(TEntity entity);
    void Delete(TEntity entity);

}
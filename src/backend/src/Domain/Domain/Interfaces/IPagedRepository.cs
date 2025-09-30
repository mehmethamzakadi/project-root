namespace Domain.Interfaces;

public interface IPagedRepository<TEntity> where TEntity : class
{
    Task<PagedResult<TEntity>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}



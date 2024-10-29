namespace BlazorDiscoveryAPI.Domain.Base
{
    public interface IBaseRepository<T>
    {
        Task<IList<T>> Get();
        Task<T?> GetById(Guid id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Commit();
    }
}

namespace BlazorDiscoveryAPI.Domain.Base
{
    public interface IBaseRepository<T>
    {
        Task<IList<T>> Get();
        Task<T?> GetById(Guid id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Commit();
    }
}

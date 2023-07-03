using EatEasy.Domain.Core.Domain;

namespace EatEasy.Domain.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        void AddAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Remove(T entity);
    }
}

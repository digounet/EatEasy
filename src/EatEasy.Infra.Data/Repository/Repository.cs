using EatEasy.Domain.Core.Data;
using EatEasy.Domain.Core.Domain;
using EatEasy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatEasy.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public IUnitOfWork UnitOfWork => Db;
        protected readonly EatEasyContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(EatEasyContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
        }

        ~Repository()
        {
            Dispose(false);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public void AddAsync(T entity, CancellationToken cancellationToken)
        {
            DbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}

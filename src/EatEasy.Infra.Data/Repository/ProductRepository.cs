using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using EatEasy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatEasy.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EatEasyContext context) : base(context)
        {
        }

        public async Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(p => p.Category)
                .Where(c => c.Name.ToLower().Equals(name.ToLower()))
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(p => p.Category)
                .Where(c => c.CategoryID == categoryId)
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(p => p.Category)
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}

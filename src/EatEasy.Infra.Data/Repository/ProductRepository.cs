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
            return await DbSet.Where(c => c.Name.ToLowerInvariant().Equals(name.ToLowerInvariant()))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.CategoryID == categoryId)
                .ToListAsync(cancellationToken);
        }
    }
}

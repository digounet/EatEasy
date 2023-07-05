using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using EatEasy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatEasy.Infra.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(EatEasyContext context) : base(context)
        {
        }

        public async Task<Category> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.Name.ToLower().Equals(name.ToLower()))
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}

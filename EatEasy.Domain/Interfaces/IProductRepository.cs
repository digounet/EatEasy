using EatEasy.Domain.Core.Data;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken);
    }
}

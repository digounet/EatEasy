using EatEasy.Domain.Core.Data;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}

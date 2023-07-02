using EatEasy.Domain.Core.Data;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetByOrderAsync(Guid orderId, CancellationToken cancellationToken);
    }
}

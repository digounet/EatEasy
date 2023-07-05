using EatEasy.Domain.Core.Data;
using EatEasy.Domain.Enums;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetByClientAsync(Guid clientId, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetByDateAsync(DateTime date, CancellationToken cancellationToken);
        Task<Order> GetBySequenceAsync(int sequence, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetByDateAndStatusAsync(DateTime date, OrderStatus orderStaus, CancellationToken cancellationToken);
        Task<int> GetNextSequenceByDateAsync(DateTime date, CancellationToken cancellationToken);
    }
}

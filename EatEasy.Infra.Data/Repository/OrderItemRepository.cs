using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using EatEasy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatEasy.Infra.Data.Repository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(EatEasyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderAsync(Guid orderId, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.OrderId == orderId)
                .ToListAsync(cancellationToken);
        }
    }
}

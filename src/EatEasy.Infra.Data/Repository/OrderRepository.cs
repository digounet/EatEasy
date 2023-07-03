using EatEasy.Domain.Enums;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using EatEasy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatEasy.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EatEasyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetByClientAsync(Guid clientId, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.ClientId == clientId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByDateAsync(DateTime date, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.OrderDate == date)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByDateAndStatusAsync(DateTime date, OrderStatus orderStaus, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.OrderDate == date && c.OrderStatus == orderStaus)
                .ToListAsync(cancellationToken);
        }
    }
}

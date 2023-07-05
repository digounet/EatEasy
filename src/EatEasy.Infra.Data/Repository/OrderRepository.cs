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

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByClientAsync(Guid clientId, CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ThenInclude(c => c.Category)
                .Where(c => c.ClientId == clientId.ToString())
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByDateAsync(DateTime date, CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ThenInclude(c => c.Category)
                .Where(c => c.OrderDate == date)
                .ToListAsync(cancellationToken);
        }

        public async Task<Order> GetBySequenceAsync(int sequence, CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ThenInclude(c => c.Category)
                .Where(c => c.Sequence == sequence)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByDateAndStatusAsync(DateTime date, OrderStatus orderStaus, CancellationToken cancellationToken)
        {
            return await DbSet
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ThenInclude(c => c.Category)
                .Where(c => c.OrderDate == date && c.OrderStatus == orderStaus)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetNextSequenceByDateAsync(DateTime date, CancellationToken cancellationToken)
        {
            var response = await DbSet.Where(o => o.OrderDate == date).MaxAsync(x => (int?)x.Sequence, cancellationToken) ?? 0;
            return response + 1;
        }
    }
}

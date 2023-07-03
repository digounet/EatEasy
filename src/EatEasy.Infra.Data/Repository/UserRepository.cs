using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using EatEasy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatEasy.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly EatEasyContext Db;
        protected readonly DbSet<User> DbSet;

        public UserRepository(EatEasyContext context) 
        {
            Db = context;
            DbSet = Db.Set<User>();
        }

        public async Task<User> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.CPF.Equals(cpf))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}

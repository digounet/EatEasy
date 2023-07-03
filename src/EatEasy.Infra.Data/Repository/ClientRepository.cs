using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Models;
using EatEasy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatEasy.Infra.Data.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(EatEasyContext context) : base(context)
        {
        }


        public async Task<Client> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.CPF.Equals(cpf))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Client> LoginAsync(string cpf, string password, CancellationToken cancellationToken)
        {
            return await DbSet.Where(c => c.CPF.Equals(cpf) && c.Password.Equals(password))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}

using EatEasy.Domain.Core.Data;
using EatEasy.Domain.Models;

namespace EatEasy.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetByCpfAsync(string cpf, CancellationToken cancellationToken);
        Task<Client> LoginAsync(string cpf, string password, CancellationToken cancellationToken);
    }
}

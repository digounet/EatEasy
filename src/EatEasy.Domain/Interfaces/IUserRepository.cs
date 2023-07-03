using EatEasy.Domain.Models;

namespace EatEasy.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByCpfAsync(string cpf, CancellationToken cancellationToken);
    }
}

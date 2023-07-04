using EatEasy.Application.ViewModels;

namespace EatEasy.Application.Interface;

public interface ITokenService
{
    public Task<TokenViewModel?> CreateToken(string cpf);
}
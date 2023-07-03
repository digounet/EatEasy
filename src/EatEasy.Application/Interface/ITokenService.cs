using EatEasy.Application.ViewModels;

namespace EatEasy.Application.Interface;

public interface ITokenService
{
    public TokenViewModel? CreateToken(UserViewModel user);
}
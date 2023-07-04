using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Core.Domain;
using EatEasy.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static System.Int32;

namespace EatEasy.Application.Services;

public class TokenService : ITokenService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public TokenService(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration.GetSection("TokenConfigurations");
    }

    public async Task<TokenViewModel?> CreateToken(string cpf)
    {
        var user = await _userManager.FindByNameAsync(cpf);

        if (user == null)
        {
            throw new DomainException("Usuário não encontrado");
        }

        var role = await _userManager.GetRolesAsync(user);

        var expiration = DateTime.UtcNow.AddMinutes(Parse(_configuration["Minutes"]));
        var token = CreateJwtToken(
            CreateClaims(user, role[0]),
            CreateSigninCredentials(),
            expiration
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return new TokenViewModel
        {
            Cpf = user.CPF,
            Email = user.Email,
            AccessToken = tokenHandler.WriteToken(token),
            Expiration = expiration
        };
    }

    private SigningCredentials CreateSigninCredentials()
    {
        return new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretJWTKey"])),
            SecurityAlgorithms.HmacSha256
        );
    }

    private List<Claim> CreateClaims(User user, string role)
    {
        try
        {
            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, "TokenForEatEasyApiAuth"),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new(ClaimTypes.NameIdentifier, user.CPF),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, role)

            };

            return claims;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
        new(_configuration["Issuer"],
            _configuration["Audience"],
            claims,
            expires: expiration,
            signingCredentials: credentials);
}
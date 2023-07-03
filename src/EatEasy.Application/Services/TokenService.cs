using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static System.Int32;

namespace EatEasy.Application.Services;

public class TokenService : ITokenService
{

    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("TokenConfigurations");
    }

    public TokenViewModel? CreateToken(UserViewModel user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(Parse(_configuration["Minutes"]));
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigninCredentials(),
            expiration
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return new TokenViewModel
        {
            Cpf = user.Cpf,
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

    private List<Claim> CreateClaims(UserViewModel user)
    {
        try
        {
            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, "TokenForEatEasyApiAuth"),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new(ClaimTypes.NameIdentifier, user.Cpf),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email)

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
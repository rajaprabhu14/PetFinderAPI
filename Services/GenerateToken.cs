using Microsoft.IdentityModel.Tokens;
using PetFinder.DTO.login;
using PetFinder.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PetFinder.Services;

public class GenerateToken(IConfiguration configuration) : ILoginRepository
{
    private readonly IConfiguration _configuration = configuration;

    public Task<LoginResponse> GenerateJwtToken(string userName)
    {
        List<Claim> claims = [];
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, userName);
            new Claim(JwtRegisteredClaimNames.NameId, Guid.NewGuid().ToString());
        }

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("6512026bf2967b862f943083ff088077ad4f3f40c05a82e9ddbc713839d02264"));
        var credentials = new SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
         );

        var result =  new JwtSecurityTokenHandler().WriteToken(token);

        return Task.FromResult(new LoginResponse()
        {
            Result = result,
            IsLoggedIn = true
        });
    }
}

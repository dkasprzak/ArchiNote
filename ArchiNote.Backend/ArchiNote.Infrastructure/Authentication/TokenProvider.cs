using System.Security.Claims;
using System.Text;
using ArchiNote.Application.Abstractions.Authentication;
using ArchiNote.Domain.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace ArchiNote.Infrastructure.Authentication;

internal sealed class TokenProvider(IConfiguration configuration) : ITokenProvider
{
    public string Create(User user, Guid? activeOrganizationId = null)
    {
        var secretKey = configuration["Jwt:SecretKey"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email)
        };

        // format "orgId:role"
        foreach (var orgUser in user.OrganizationUsers)
        {
            claims.Add(new("org_role", $"{orgUser.OrganizationId}:{orgUser.Role}"));
        }
        
        //active org dla admin/employee itd.
        if (activeOrganizationId.HasValue)
        {
            claims.Add(new("active_org", activeOrganizationId.Value.ToString()));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:ExpirationInMinutes")),
            SigningCredentials = credentials,
            Issuer = configuration["Jwt:Issuer"],
            Audience = configuration["Jwt:Audience"]
        };
        
        var handler = new JsonWebTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);

        return token;
    }
}
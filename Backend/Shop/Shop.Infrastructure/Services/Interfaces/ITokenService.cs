using Microsoft.IdentityModel.Tokens;
using Shop.Domain.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Shop.Infrastructure.Services.Interfaces
{
    public interface ITokenService
    {
        public JwtSecurityToken GenerateTokenSettings(SigningCredentials signingCredentials, List<Claim> claims);

        public Task<List<Claim>> GetClaims(User user);

        public SigningCredentials GetSigningCredentials();

        public string GenerateRefreshToken();

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
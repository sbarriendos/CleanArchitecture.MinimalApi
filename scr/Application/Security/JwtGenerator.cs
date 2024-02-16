using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Security;
public class JwtGenerator(IOptions<JwtSettings> jwtSettings, IOptions<LoginSettings> loginSettings)
{
    private readonly string _secretKey = jwtSettings.Value.SecretKey;
    private readonly string _issuer = jwtSettings.Value.Issuer;
    private readonly string _audience = jwtSettings.Value.Audience;
    private readonly int _expiryMinutes = jwtSettings.Value.ExpiryMinutes;

    public string GenerateToken(string userId)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes(_secretKey);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.NameIdentifier, userId)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_expiryMinutes),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public bool IsValidUser(string? username, string? password)
    {
        return (username, password) switch
        {
            (null, _) => false,
            (_, null) => false,
            (var user, var pass) when user == loginSettings.Value.Username && pass == loginSettings.Value.Password => true,
            _ => false
        };
    }
}

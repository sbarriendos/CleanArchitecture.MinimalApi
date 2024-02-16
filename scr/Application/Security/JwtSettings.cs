using System.ComponentModel.DataAnnotations;

namespace Application.Security;
public class JwtSettings
{
    [Required]
    public required string Issuer { get; set; }
    [Required]
    public required string Audience { get; set; }
    [Required]
    public required int ExpiryMinutes { get; set; }
    [Required]
    public required string SecretKey { get; set; }
}
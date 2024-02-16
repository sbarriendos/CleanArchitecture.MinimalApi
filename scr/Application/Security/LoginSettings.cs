using System.ComponentModel.DataAnnotations;

namespace Application.Security;
public class LoginSettings
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
}

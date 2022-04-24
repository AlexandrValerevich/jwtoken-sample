using System.ComponentModel.DataAnnotations;

namespace JwtAuthentification.Contracts.V1.Requests;

public class RegisterRequest
{
    [EmailAddress]
    public string Email { get; set; } 
    public string Password { get; set; }
}

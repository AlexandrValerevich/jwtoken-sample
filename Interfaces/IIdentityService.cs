using JwtAuthentification.Domain;

namespace JwtAuthentification.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthentificationResult> RegisterAsync(string email, string password);
    }
}
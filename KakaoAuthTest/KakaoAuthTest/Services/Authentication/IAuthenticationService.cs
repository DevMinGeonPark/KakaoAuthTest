using System.Threading.Tasks;
using KakaoAuthTest.Models;

namespace KakaoAuthTest.Services.Authentication
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        User AuthenticatedUser { get; }

        Task<bool> LoginAsync(string email, string password);

        Task LoginWithSNSAsync(SNSProvider provider);

        Task<bool> UserIsAuthenticatedAndValidAsync();

        Task LogoutAsync();
    }
}

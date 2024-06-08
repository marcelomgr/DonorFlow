using DonorFlow.Core.Entities;

namespace DonorFlow.Core.Services.AuthService
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}

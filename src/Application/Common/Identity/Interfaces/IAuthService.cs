using Domain.Entities.Identity;

namespace Application.Common.Identity.Interfaces;

public interface IAuthService
{
    Task<string> GenerateJwtTokenAsync(ApplicationUser user);
    bool IsPasswordExpired(ApplicationUser user, int expiryDays = 90);
}

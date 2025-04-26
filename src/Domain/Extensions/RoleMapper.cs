using Domain.Constants;
using Domain.Enums;

namespace Domain.Extensions;

public static class RoleMapper
{
    public static string ToRoleName(this UserRole role)
    {
        return role switch
        {
            UserRole.Admin => Roles.Admin,
            UserRole.Manager => Roles.Manager,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }
}

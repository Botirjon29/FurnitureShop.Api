using Microsoft.AspNetCore.Identity;

namespace FurnitureShop.Api.Entities;

public class UserEntity : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public EUserStatus Status { get; set; }

    public virtual ICollection<OrganizationUser>? Organizations { get; set; }
}

using System.Security.Claims;
using FurnitureShop.Api.Dtos;
using FurnitureShop.Api.ViewModel;

namespace FurnitureShop.Api.Services;

public interface IOrganizationService
{
    Task<List<OrganizationView>> GetOrganizationsAsync();
    Task<OrganizationView> GetOrganizationByIdAsync(Guid organizationId);
    Task AddOrganization(ClaimsPrincipal claims, CreateOrganizationDto organizationDto);
    Task UpdateOrganization(Guid organizationId, UpdateOrganizationDto organizationDto);
    Task DeleteOrganization(Guid organizationId);
}

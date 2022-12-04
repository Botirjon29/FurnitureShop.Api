using System.Data;
using FurnitureShop.Api.Data;
using FurnitureShop.Api.Dtos;
using FurnitureShop.Api.Entities;
using FurnitureShop.Api.Exceptions;
using FurnitureShop.Api.ViewModel;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FurnitureShop.Api.Services;

public class OrganizationService : IOrganizationService
{
    private readonly AppDbContext _appDbContext;

    public OrganizationService(AppDbContext? appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<OrganizationView>> GetOrganizationsAsync()
    {
        return (await _appDbContext.Organizations!.ToListAsync()).Adapt<List<OrganizationView>>();
    }

    public async Task<OrganizationView> GetOrganizationByIdAsync(Guid organizationId)
    {
        var organization = await _appDbContext.Organizations!.FindAsync(organizationId);

        if (organization is null)
            throw new OrganizationNotFoundException();

        return organization.Adapt<OrganizationView>();
    }

    public async Task AddOrganization(ClaimsPrincipal claims, CreateOrganizationDto organizationDto)
    {
        var organization = organizationDto.Adapt<Organization>();
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        organization.Users = new List<OrganizationUser>()
        {
            new OrganizationUser()
            {
                Role = ERole.Owner,
                UserId = userId
            }
        };

        await _appDbContext.Organizations!.AddAsync(organization);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateOrganization(Guid organizationId, UpdateOrganizationDto organizationDto)
    {
        var organization = await _appDbContext.Organizations!.FindAsync(organizationId);

        if (organization is null)
            throw new OrganizationNotFoundException();

        organization.Name = organizationDto.Name;

        _appDbContext.Organizations!.Update(organization);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteOrganization(Guid organizationId)
    {
        var organization = await _appDbContext.Organizations!.FindAsync(organizationId);

        if (organization is null)
            throw new OrganizationNotFoundException();

        _appDbContext.Organizations!.Remove(organization);
        await _appDbContext.SaveChangesAsync();
    }
}



using FurnitureShop.Api.Dtos;
using FurnitureShop.Api.Services;
using FurnitureShop.Api.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private IOrganizationService _organizationService;

    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(OrganizationView), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OrganizationView>>> GetOrganizations() =>
        await _organizationService.GetOrganizationsAsync();


    [HttpGet("{organizationId:guid}")]
    [ProducesResponseType(typeof(OrganizationView), StatusCodes.Status200OK)]
    public async Task<ActionResult<OrganizationView>> GetOrganizationById(Guid organizationId) =>
        await _organizationService.GetOrganizationByIdAsync(organizationId);

    [HttpPost]
    public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDto organizationDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        await _organizationService.AddOrganization(User,organizationDto);
        return Ok();
    }

    [HttpPut("{organizationId:guid}")]
    public async Task<IActionResult> UpdateOrganization(Guid organizationId, [FromBody] UpdateOrganizationDto organizationDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        await _organizationService.UpdateOrganization(organizationId, organizationDto);
        return Ok();
    }

    [HttpDelete("{organizationId:guid}")]
    public async Task<IActionResult> DeleteOrganization(Guid organizationId)
    {
        await _organizationService.DeleteOrganization(organizationId);
        return Ok();
    }
}

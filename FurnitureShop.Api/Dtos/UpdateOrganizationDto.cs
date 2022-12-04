using System.ComponentModel.DataAnnotations;

namespace FurnitureShop.Api.Dtos;

public class UpdateOrganizationDto
{
    [Required]
    public string? Name { get; set; }
}

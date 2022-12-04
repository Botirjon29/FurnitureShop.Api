using System.ComponentModel.DataAnnotations;

namespace FurnitureShop.Api.Dtos;

public class CreateOrganizationDto
{
    [Required]
    public string? Name { get; set; }
}

namespace FurnitureShop.Api.Exceptions;

public class OrganizationNotFoundException : Exception
{
    public OrganizationNotFoundException() : base("Organization not found"){}
}

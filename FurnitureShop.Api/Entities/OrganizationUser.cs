﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureShop.Api.Entities;

public class OrganizationUser
{
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual UserEntity? User { get; set; }


    public Guid OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization? Organization { get; set; }

    public ERole Role { get; set; }
}

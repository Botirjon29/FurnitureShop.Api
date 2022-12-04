﻿using System.ComponentModel.DataAnnotations;

namespace FurnitureShop.Api.Dtos;

public class LoginUserDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}

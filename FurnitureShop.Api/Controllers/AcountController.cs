using FurnitureShop.Api.Data;
using FurnitureShop.Api.Dtos;
using FurnitureShop.Api.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShop.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AcountController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    public AcountController(AppDbContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("signUpUser")]
    public async Task<IActionResult> SignUpAsync(RegisterUserDto registerDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var user = registerDto.Adapt<UserEntity>();

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded) return BadRequest();

        var signInResult = _signInManager.SignInAsync(user, true);

        return Ok();
    }

    [HttpPost("signInUser")]
    public async Task<IActionResult> SignInAsync(LoginUserDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (!await _userManager.Users.AnyAsync(u => u.UserName == loginDto.UserName))
            return BadRequest();

        var signUser = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, isPersistent: true, true);
        if (!signUser.Succeeded) return BadRequest();

        return Ok();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{


    private readonly ITokenService _tokenService;

    private readonly DataContext _context;
    public AccountController(DataContext context, ITokenService tokenService)
    {
        this._tokenService = tokenService;
        this._context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {

        if (await UserExists(registerDto.Username))
        {
            return BadRequest("Username is taken !");
        }
        else
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await this._context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        };
    }



    private async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync((x) => x.UserName.Equals(username.ToLower()));
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName.Equals(loginDto.Username));
        if (user == null)
        {
            return Unauthorized("Invalid username !");
        }
        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computerHash.Length; i++)
        {
            if (computerHash[i] != user.PasswordHash[i])
            {
                return Unauthorized("Invalid password !");
            }
        }
        return new UserDto
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user),
            PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url
        };

    }

}


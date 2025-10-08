using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prn232Project.Data;
using Prn232Project.DTOs;
using Prn232Project.Models;
using Prn232Project.Services;
using System;

namespace Prn232Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Users> _hasher;
        private readonly ITokenServices _tokenServices;
        public AuthController(ApplicationDbContext context, IPasswordHasher<Users> hasher, ITokenServices tokenServices)
        {
            _context = context;
            _hasher = hasher;
            _tokenServices = tokenServices;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _context.Users.AnyAsync(u => u.UserName == dto.UserName))
            {
                return Conflict(new
                {
                    status = StatusCodes.Status409Conflict,
                    detail = "USERNAME_ALREADY_EXISTS",
                    message = "Username already exists"
                });
            }
            else if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return Conflict(new
                {
                    status = StatusCodes.Status409Conflict,
                    detail = "EMAIL_ALREADY_EXISTS",
                    message = "One account was registered by this email"
                });
            }
            try
            {
                var user = new Users
                {
                    UserName = dto.UserName,
                    Password = dto.Password,
                    Email = dto.Email,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                };
                user.Password = _hasher.HashPassword(user, user.Password);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
                if (role != null)
                {
                    var userRole = new UserRoles
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    };

                    await _context.UserRoles.AddAsync(userRole);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    status = StatusCodes.Status500InternalServerError,
                    detail = "INTERNAL_SERVER_ERROR",
                    message = ex.Message
                });
            }
            return Ok(new
            {
                status = StatusCodes.Status200OK,
                detail = "Register successfully",
            });
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _context.Users.Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (user == null)
                return Unauthorized(new
                {
                    status = StatusCodes.Status401Unauthorized,
                    detail = "INVALID_CREDENTIAL",
                    message = "Invalid username or password"
                });

            var result = _hasher.VerifyHashedPassword(user, user.Password, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new
                {
                    status = StatusCodes.Status401Unauthorized,
                    detail = "INVALID_CREDENTIAL",
                    message = "Invalid username or password"
                });
            var accessToken = string.Empty;
            var refreshToken = new RefreshToken();
            try
            {
                accessToken = _tokenServices.CreateAccessToken(dto.UserName);
                refreshToken = _tokenServices.CreateRefreshToken(dto.UserName);
                refreshToken.UserId = user.Id;
                await _context.RefreshTokens.AddAsync(refreshToken);
                await _context.SaveChangesAsync();
                Response.Cookies.Append("accessToken", accessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
                Response.Cookies.Append("refreshToken", refreshToken.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    status = StatusCodes.Status500InternalServerError,
                    detail = "INTERNAL_SERVER_ERROR",
                    message = e.Message
                });
            }
            return Ok(new
            {
                status = StatusCodes.Status200OK,
                detail = "Login successful",
                accessToken = accessToken,
                refreshToken = refreshToken.Token,
            });
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (refreshToken == null)
            {
                return Unauthorized(new
                {
                    status = StatusCodes.Status401Unauthorized,
                    detail = "MISSING_REFRESH_TOKEN ",
                    message = "No refresh token provided"
                });
            }
            var oldRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(u => u.Token == refreshToken);
            if (oldRefreshToken==null)
            {
                return Unauthorized(new
                {
                    status = StatusCodes.Status401Unauthorized,
                    detail = "INVALID_REFRESH_TOKEN",
                    message = "Refresh token is invalid"
                });
            }
            if (oldRefreshToken.IsRevoked == true)
            {
                return Unauthorized(new
                {
                    status = StatusCodes.Status401Unauthorized,
                    detail = "INVALID_REFRESH_TOKEN",
                    message = "Refresh token is revoked"
                });
            }
            if (oldRefreshToken.Expires<DateTime.UtcNow)
            {
                return Unauthorized(new
                {
                    status = StatusCodes.Status401Unauthorized,
                    detail = "INVALID_REFRESH_TOKEN",
                    message = "Refresh token is expired, please login again"
                });
            }
            var accessToken = string.Empty;
            var newRefreshToken = new RefreshToken();
            var user = await _context.Users
                 .Include(u => u.RefreshTokens)
                 .FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.Token == refreshToken));
            if (user == null)
            {
                return Unauthorized(new
                {
                    status = StatusCodes.Status401Unauthorized,
                    detail = "INVALID_REFRESH_TOKEN",
                    message = "No user with this token"
                });
            }
            try
            {
                accessToken = _tokenServices.CreateAccessToken(user.UserName);
                newRefreshToken = _tokenServices.CreateRefreshToken(user.UserName);
                oldRefreshToken.IsRevoked = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    status = StatusCodes.Status500InternalServerError,
                    detail = "INTERNAL_SERVER_ERROR",
                    message = ex.Message
                });
            }
            return Ok(new
            {
                status = StatusCodes.Status200OK,
                accessToken = accessToken,
                refreshToken = newRefreshToken.Token,
            });
        }

    }
}

using Microsoft.IdentityModel.Tokens;
using Prn232Project.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Prn232Project.Services
{
    public class TokenServiceVer1:ITokenServices
    {
        private readonly IConfiguration _config;
        private readonly IUserServices _userService;
        public TokenServiceVer1(IConfiguration config, IUserServices userService)
        {
            _config = config;
            _userService = userService;
        }   
        public string CreateAccessToken(string username)
        {
            var user= _userService.GetUsers(username);
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
           {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role,  _userService.GetRoles(username).Name),
                new Claim("security_stamp", user.SecurityStamp ?? ""),
                new Claim("concurrency_stamp", user.ConcurrencyStamp ?? "")
            };
            var token = new JwtSecurityToken(
               issuer: jwtSettings["Issuer"],
               audience: jwtSettings["Audience"],
               claims: claims,
               expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["AccessTokenMinutes"])),
               signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public RefreshToken CreateRefreshToken(string username)
        {
            var randomBytes = new byte[64];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            var token = Convert.ToBase64String(randomBytes);
            var user = _userService.GetUsers(username);
            return new RefreshToken
            {
                Token = token,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:RefreshTokenMinutes"]??"60")),
                Created = DateTime.UtcNow,
                IsRevoked=false,
                UserId = user.Id
            };
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prn232Project.Data;
using Prn232Project.Models;
using Prn232Project.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers().
    ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            Status = StatusCodes.Status400BadRequest,
        };
        return new BadRequestObjectResult(problemDetails);
    };
}); ;
//JWT configuration
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});



//Register services
builder.Services.AddScoped<IUserServices, UserServiceVer1>();
builder.Services.AddScoped<ITokenServices, TokenServiceVer1>();
builder.Services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();


var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

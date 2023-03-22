using GigaChatApi.Dtos;
using GigaChatApi.Middleware;
using GigaChatApi.Models;
using GigaChatApi.Security;
using GigaChatApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Redis.OM;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<AppUser, UserDTO>();
});

builder.Services.AddControllers();

builder.Services.AddSingleton(new RedisConnectionProvider("redis://" + Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING")!));
builder.Services.AddHostedService<IndexCreationService>();
//builder.Services.AddIdentityCore<AppUser>()
//    .AddUserManager<UserManager<AppUser>>()
//    .AddSignInManager<SignInManager<AppUser>>()
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddRedisStores(options =>
    {
        options.EndPoints.Add(Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING")!);
    })
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("GIGACHAT_TOKEN_KEY")!));
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateAudience = false,
        ValidateIssuer = false,
    };
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped<JWTGenerator>();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

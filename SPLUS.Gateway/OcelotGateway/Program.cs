using CacheManager.Core;
using JwtTokenAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway.Middleware;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Config Ocelot
        builder.Configuration.AddJsonFile("ocelot.json");

        #region Authen
        //var key = Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JwtKey"]!);
        //string authenticationProviderKey = "TestKey";
        //builder.Services.AddAuthentication(option =>
        //{
        //    option.DefaultAuthenticateScheme = authenticationProviderKey;
        //    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(authenticationProviderKey, options =>
        //{
        //    options.RequireHttpsMetadata = false;
        //    options.SaveToken = true;
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateIssuerSigningKey = true,
        //        ValidateIssuer = true,
        //        ValidateAudience = false
        //    };
        //});
        #endregion

        builder.Services.AddOcelot(builder.Configuration);

        builder.Services.AddJwtAuthentication();

        var app = builder.Build();

        await app.UseOcelot(new TokenHandlerMiddleware(builder.Configuration));

        app.UseAuthentication();
        app.UseAuthorization();

        app.Run();
    }
}

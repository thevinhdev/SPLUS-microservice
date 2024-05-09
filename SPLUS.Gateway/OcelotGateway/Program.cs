using JwtTokenAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Authen
        //var key = Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JwtKey"]!);
        //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        //builder.Services.AddAuthentication(option =>
        //{
        //    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(options =>
        //{
        //    options.RequireHttpsMetadata = false;
        //    options.SaveToken = true;
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateIssuerSigningKey = true,
        //        ValidateIssuer = false,
        //        ValidateAudience = false
        //    };
        //});
        #endregion

        builder.Configuration.AddJsonFile("ocelot.json", false, false);

        builder.Services.AddOcelot(builder.Configuration);
        builder.Services.AddJwtAuthentication();

        var app = builder.Build();

        await app.UseOcelot();

        app.UseAuthentication();
        app.UseAuthorization();

        app.Run();
    }
}

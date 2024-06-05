using AuthApi.Services;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway.Middleware;

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

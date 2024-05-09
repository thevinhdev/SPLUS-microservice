using Microsoft.OpenApi.Models;
using SPLUS.Tenant.Infrastructure.Settings;
using SPLUS.Tenant.Application.Products;
using SPLUS.Tenant.Application.Shoes;
using Infrastructure.Extensions;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;

namespace SPLUS.Tenant.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }

        public IConfiguration config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Multitenant.Api", Version = "v1" });
            });
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShoeService, ShoeService>();
            services.Configure<TenantSettings>(config.GetSection(nameof(TenantSettings)));
            services.AddAndMigrateTenantDatabases(config);

            #region Authen
            var key = Encoding.UTF8.GetBytes(config["AppSettings:JwtKey"]!);
            string authenticationProviderKey = "TestKey";
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = authenticationProviderKey;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(authenticationProviderKey, options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Multitenant.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SPLUS.Customer.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Customer.Infrastructure.Services
{
    public interface ITenantService
    {
        public string GetDatabaseProvider();

        public string GetConnectionString();

        public Tenant GetTenant();
    }
    public class TenantService : ITenantService
    {
        private readonly TenantSettings _tenantSettings;
        private HttpContext _httpContext;
        private Tenant _currentTenant;

        public TenantService(IOptions<TenantSettings> tenantSettings, IHttpContextAccessor contextAccessor)
        {
            _tenantSettings = tenantSettings.Value;
            _httpContext = contextAccessor.HttpContext;
            if (_httpContext != null)
            {
                string authHeader = _httpContext.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Bearer"))
                {
                    var handler = new JwtSecurityTokenHandler();
                    authHeader = authHeader.Replace("Bearer ", "").Trim();
                    var jsonToken = handler.ReadToken(authHeader);
                    var token = handler.ReadToken(authHeader) as JwtSecurityToken;
                    string tenant = token.Claims.First(claim => claim.Type == "tenant").Value;

                    if (string.IsNullOrEmpty(tenant)) throw new Exception("Invalid Tenant!");
                    SetTenant(tenant);
                }
                //if (_httpContext.Request.Headers.TryGetValue("tenant", out var tenantId))
                //{
                //    SetTenant(tenantId);
                //}
                //else
                //{
                //    throw new Exception("Invalid Tenant!");
                //}
            }
        }

        private void SetTenant(string tenantId)
        {
            _currentTenant = _tenantSettings.Tenants.Where(a => a.TID == tenantId).FirstOrDefault();
            if (_currentTenant == null) throw new Exception("Invalid Tenant!");
            if (string.IsNullOrEmpty(_currentTenant.ConnectionString))
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
        }

        private void SetDefaultConnectionStringToCurrentTenant()
        {
            _currentTenant.ConnectionString = _tenantSettings.Defaults.ConnectionString;
        }

        public string GetConnectionString()
        {
            return _currentTenant?.ConnectionString;
        }

        public string GetDatabaseProvider()
        {
            return _tenantSettings.Defaults?.DBProvider;
        }

        public Tenant GetTenant()
        {
            return _currentTenant;
        }
    }
}

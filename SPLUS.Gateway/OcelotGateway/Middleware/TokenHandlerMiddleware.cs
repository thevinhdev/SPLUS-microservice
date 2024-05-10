using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Ocelot.Middleware;
using OcelotGateway.Models;
using System.Reflection.PortableExecutable;
using System.Security.Policy;
using System.Text;

namespace OcelotGateway.Middleware
{
    public class TokenHandlerMiddleware : OcelotPipelineConfiguration
    {
        private IConfiguration _configuration { get; }
        public TokenHandlerMiddleware(IConfiguration configuration)
        {
            _configuration = configuration;
            PreAuthenticationMiddleware = async (ctx, next) =>
            {
                await ProcessRequestAsync(ctx, next);
            };
        }

        public async Task ProcessRequestAsync(HttpContext ctx, Func<Task> next)
        {
            try
            {
                string path = ctx.Request.Path;
                if (path != "/api-gateway/Auth/GenerateToken" && path != "/api-gateway/Auth/GenerateRefreshToken")
                {
                    string token = ctx.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
                    if (string.IsNullOrEmpty(token))
                        throw new UnauthorizedAccessException("Unauthorized");

                    // Refreshtoken
                    string domain = _configuration["Token:EndPoint"]!;
                    var url = domain + "/api/Auth/GenerateRefreshToken";
                    var tokenRequest = new RefreshTokenModel
                    {
                        TokenRefresh = token
                    };
                    var jsonRequest = JsonConvert.SerializeObject(tokenRequest);
                    var result = await PostAsync<ApiResponse>(url, jsonRequest);
                    if (result != null && !string.IsNullOrEmpty(result.Token))
                    {
                        // Set new token to header and re-send request
                        ctx.Request.Headers.Remove("Authorization");
                        ctx.Request.Headers.Append("Authorization", "Bearer " + result.Token);
                    }
                }
                await next.Invoke();
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }
        }
        public async Task<T> PostAsync<T>(string uri, string data)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(content));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

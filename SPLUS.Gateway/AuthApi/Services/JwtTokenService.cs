using AuthApi.Models;
using JwtTokenAuthentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthApi.Services
{
    public class JwtTokenService
    {
        private readonly List<User> _users = new()
        {
            new("admin", "123456", "Administrator", "", new[] { "shoes.read" }),
            new("user01", "u$3r01", "User", "", new[] { "shoes.read" })
        };

        public AuthenticationToken? GenerateAuthToken(LoginModel loginModel)
        {
            var user = _users.FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);

            if (user is null)
            {
                return null;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(5);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim("role", user.Role),
                new Claim("tenant", loginModel.Tenant),
                new Claim("scope", string.Join(" ", user.Scopes))
            };

            //var tokenOptions = new JwtSecurityToken(
            //    issuer: "https://localhost:5002",
            //    claims: claims,
            //    expires: expirationTimeStamp,
            //    signingCredentials: signingCredentials
            //);

            var createJwtSecurityToken = CreateJwtSecurityToken(claims, expirationTimeStamp, signingCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(createJwtSecurityToken);

            return new AuthenticationToken(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
        }

        public AuthenticationToken? GenerateRefreshToken(RefreshTokenModel tokenModel)
        {
            //Chưa validate expired and username
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(tokenModel.TokenRefresh) as JwtSecurityToken;
            string tenant = token.Claims.First(claim => claim.Type == "tenant").Value;
            string name = token.Claims.First(claim => claim.Type == "name").Value;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(5);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, name),
                new Claim("role", ""),
                new Claim("tenant", tenant),
                new Claim("scope", string.Join(" ", ""))
            };

            var createJwtSecurityToken = CreateJwtSecurityToken(claims, expirationTimeStamp, signingCredentials);
            
            var newTokenString = new JwtSecurityTokenHandler().WriteToken(createJwtSecurityToken);
            return new AuthenticationToken(newTokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
        }

        private JwtSecurityToken CreateJwtSecurityToken(List<Claim> claims, DateTime expirationTimeStamp, SigningCredentials signingCredentials)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5002",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Zawodnicy.WebApp.Models
{
    public class JWToken
    {

        private IConfiguration Configuration;
        public JWToken(IConfiguration configuration)
        {
            Configuration = configuration;

            TokenUrl = "http://localhost:5000";
            SecretKey = "SuperTajneHaslo1234";

            TokenString = GenerateJSONWebToken();
        }
        public string TokenUrl { get; set; }
        public string SecretKey { get; set; }
        public string TokenString { get; set; }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{SecretKey}"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: $"{TokenUrl}",
                audience: $"{TokenUrl}",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

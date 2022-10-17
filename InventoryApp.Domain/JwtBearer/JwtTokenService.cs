using InventoryApp.Common;
using InventoryApp.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.JwtBearer
{
    public class JwtTokenService : IJwtTokenService
    {
        private IConfigurationRoot _configuration;
        public JwtTokenService()
        {
            _configuration = Appsetting.GetConfiguration();
        }
        public JwtToken GenerateJwtToken(Users user, IEnumerable<string> roles = null)
        {
            var userIdInString = user.Id.ToString();

            double tokenTimeOutMinutes = Convert.ToDouble(_configuration.GetSection("Security:Jwt:TokenTimeOutMinutes").Value);
            var timeout = TimeSpan.FromMinutes(tokenTimeOutMinutes);
            var issueDate = DateTime.UtcNow;
            var expiredDate = issueDate.Add(timeout);

            var claims = new List<Claim>();
            string tokenSubject = _configuration.GetSection("Security:Jwt:Subject").Value;
            claims.Add(new Claim("Subject:", tokenSubject));

            if (roles != null)
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userIdInString));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Security:Jwt:SecurityKey").Value));
            var sigingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtPayload = new JwtPayload(
                 issuer: _configuration.GetSection("Security:Jwt:Issuer").Value,
                 audience: _configuration.GetSection("Security:Jwt:Audience").Value,
                 claims: claims,
                 notBefore: null,
                 expires: expiredDate,
                 issuedAt: issueDate
                );

            var jwtHeader = new JwtHeader(sigingCredential);
            var jwtToken = new JwtSecurityToken(jwtHeader, jwtPayload);

            return new JwtToken
            {
                Access_token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expires_in = timeout.TotalSeconds,
                Expires_date = expiredDate,
                Issue_date = issueDate,
                Token_type = "Bearer"
            };
        }
    }
}

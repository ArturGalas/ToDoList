using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo_List_Core.Models;
using ToDo_List_Infrastructure.DTO;
using ToDo_List_Infrastructure.Extensions;
using ToDo_List_Infrastructure.Settings;

namespace ToDo_List_Infrastructure.Services
{
    public class JwtHanlder : IJwtHandler
    {
        private readonly JwtSettings _jwtsettings;
        public JwtHanlder(IOptions<JwtSettings> jwtsettings)
        {
            _jwtsettings= jwtsettings.Value;
        }
        public JWTDTO CreateToken(Guid userId, Role role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Name, userId.ToString()),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString()),
            };
            var expires = now.AddMinutes(_jwtsettings.ExpiryMinutes);
            var singingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Key)),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _jwtsettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: singingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JWTDTO
            {
                Token = token,
                Expires = expires.ToTimestamp(),
            };
        }
    }
}

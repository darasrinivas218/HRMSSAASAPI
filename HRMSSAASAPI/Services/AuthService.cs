using HRMSSAASAPI.Application.DTOs;
using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HRMSSAASAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly MyDbContext _db;
        private readonly IConfiguration _config;
        private static readonly HashSet<string> _invalidatedTokens = new();

        public AuthService(MyDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _db.UserAccounts
                .FirstOrDefaultAsync(u =>
                    (u.Username == request.UsernameOrEmail || u.Email == request.UsernameOrEmail)
                    && u.IsActive);

            if (user == null)
                throw new Exception("Invalid username or password.");

            if (!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                user.FailedLoginAttempts += 1;
                await _db.SaveChangesAsync();
                throw new Exception("Invalid username or password.");
            }

            user.FailedLoginAttempts = 0;
            user.LastLogin = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Username = user.Username,
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };
        }

        public async Task<bool> LogoutAsync(string token)
        {
            _invalidatedTokens.Add(token);
            await Task.CompletedTask;
            return true;
        }

        private bool VerifyPassword(string password, string hash, string salt)
        {
            using var hmac = new HMACSHA512(Convert.FromBase64String(salt));
            var computed = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computed == hash;
        }

        private string GenerateJwtToken(UserAccount user)
        {
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expiry = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:ExpiryMinutes"]));

            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Name, user.Username),
            //    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            //    new Claim(ClaimTypes.Role, user.RoleId.ToString())
            //};

            //var token = new JwtSecurityToken(
            //    issuer: _config["Jwt:Issuer"],
            //    audience: _config["Jwt:Audience"],
            //    claims: claims,
            //    expires: expiry,
            //    signingCredentials: creds
            //);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                   new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                   new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return tokenHandler.WriteToken(token);
        }

        public static bool IsTokenInvalidated(string token) => _invalidatedTokens.Contains(token);
    }
}

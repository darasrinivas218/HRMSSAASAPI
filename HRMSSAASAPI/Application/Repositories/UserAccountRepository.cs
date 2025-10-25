using HRMSSAASAPI.Application.DTOs;
using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HRMSSAASAPI.Application.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly MyDbContext _myDbContext;

        public UserAccountRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<UserAccount>> GetAllUserAsync()
        {
            return await _myDbContext.UserAccounts
                .AsNoTracking()
                .Where(d => d.IsActive)
                .ToListAsync();
        }

        public async Task<UserAccount> GetUserByIdAsync(int id)
        {
            return await _myDbContext.UserAccounts.FindAsync(id);
        }

        public async Task<UserAccount> CreateUserAsync(UserAccountCreateDto dto)
        {
            // Hash password
            CreatePasswordHash(dto.Password, out string hash, out string salt);

            var user = new UserAccount
            {
                EmployeeId = dto.EmployeeId,
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                RoleId = dto.RoleId
            };

            _myDbContext.UserAccounts.Add(user);
            await _myDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserAccount> UpdateUserAsync(UserAccountUpdateDto dto)
        {
            var user = await _myDbContext.UserAccounts.FindAsync(dto.UserId);
            if (user == null) return null;

            if (!string.IsNullOrEmpty(dto.Email)) user.Email = dto.Email;
            if (dto.IsActive.HasValue) user.IsActive = dto.IsActive.Value;
            if (dto.TwoFactorEnabled.HasValue) user.TwoFactorEnabled = dto.TwoFactorEnabled.Value;

            user.UpdatedDate = DateTime.Now;

            await _myDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _myDbContext.UserAccounts.FindAsync(id);
            if (user == null) return false;

            _myDbContext.UserAccounts.Remove(user);
            await _myDbContext.SaveChangesAsync();
            return true;
        }

        private void CreatePasswordHash(string password, out string hash, out string salt)
        {
            //using var hmac = new HMACSHA256();
            //salt = Convert.ToBase64String(hmac.Key);
            //hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            using var hmac = new HMACSHA512();
            salt = Convert.ToBase64String(hmac.Key);
            hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

        }
    }
}

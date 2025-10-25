using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HRMSSAASAPI.Application.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly MyDbContext _myDbContext;
        public RolesRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _myDbContext.Roles
                 .AsNoTracking()
                 .OrderBy(r => r.RoleName)
                 .ToListAsync();
        }

        public async Task<Role> GetRolesByIdAsync(int id)
        {
            return await _myDbContext.Roles.FindAsync(id);
        }

        public async Task<Role> CreateRolesAsync(Role Role)
        {
            Role.CreatedDate = DateTime.Now;
            _myDbContext.Roles.Add(Role);
            await _myDbContext.SaveChangesAsync();
            return Role;
        }

        public async Task<bool> UpdateRolesAsync(int id, Role role)
        {
            var existing = await _myDbContext.Roles.FindAsync(id);
            if (existing == null)
                return false;

            existing.RoleName = role.RoleName;
            existing.Description = role.Description;
            existing.UpdatedDate = DateTime.Now;

            await _myDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRolesAsync(int id)
        {
            var Role = await _myDbContext.Roles.FindAsync(id);
            if (Role == null) return false;

            _myDbContext.Roles.Remove(Role);
            await _myDbContext.SaveChangesAsync();
            return true;
        }
    }
}

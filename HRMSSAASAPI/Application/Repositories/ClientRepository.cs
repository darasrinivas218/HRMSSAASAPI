using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MyDbContext _myDbContext;
        public ClientRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<IEnumerable<Client>> GetAllClientAsync()
        {
            return await _myDbContext.Clients.AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _myDbContext.Clients.FindAsync(id);
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            _myDbContext.Clients.Add(client);
            await _myDbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            _myDbContext.Entry(client).State = EntityState.Modified;
            client.UpdatedDate = DateTime.Now;
            await _myDbContext.SaveChangesAsync();
            return client;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _myDbContext.Clients.FindAsync(id);
            if (client == null)
                return false;

            _myDbContext.Clients.Remove(client);
            await _myDbContext.SaveChangesAsync();
            return true;
        }
    }
}

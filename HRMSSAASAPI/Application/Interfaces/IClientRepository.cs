using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClientAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> CreateClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
    }
}

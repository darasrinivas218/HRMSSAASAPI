using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IClientBankDetailRepository
    {
        Task<IEnumerable<ClientBankDetail>> GetAllClientBankDetailsAsync();
        Task<ClientBankDetail?> GetClientBankDetailByIdAsync(int id);
        Task<ClientBankDetail> AddClientBankDetailAsync(ClientBankDetail entity);
        Task<ClientBankDetail?> UpdateClientBankDetailAsync(int id, ClientBankDetail entity);
        Task<bool> DeleteClientBankDetailAsync(int id);
    }
}

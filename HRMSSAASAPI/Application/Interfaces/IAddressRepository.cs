using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<EmployeeAddress>> GetAllAddressesAsync();
        Task<EmployeeAddress?> GetAddressByIdAsync(int addressId);
        Task<IEnumerable<EmployeeAddress>> GetAddressesByEmployeeIdAsync(int employeeId);
        Task<EmployeeAddress> AddAddressAsync(EmployeeAddress address);
        Task<EmployeeAddress> UpdateAddressAsync(EmployeeAddress address);
        Task<bool> DeleteAddressAsync(int addressId);

        Task<IEnumerable<ClientAddress>> GetAllClientAddressesAsync();
        Task<ClientAddress?> GetClientAddressByIdAsync(int addressId);
        Task<IEnumerable<ClientAddress>> GetClientAddressesByClientIdAsync(int clientId);
        Task<ClientAddress> AddClientAddressAsync(ClientAddress address);
        Task<ClientAddress> UpdateClientAddressAsync(ClientAddress address);
        Task<bool> DeleteClientAddressAsync(int addressId);
    }
}

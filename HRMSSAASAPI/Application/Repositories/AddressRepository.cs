using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSSAASAPI.Application.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MyDbContext _myDbContext;

        public AddressRepository(MyDbContext context)
        {
            _myDbContext = context;
        }

        public async Task<IEnumerable<EmployeeAddress>> GetAllAddressesAsync()
        {
            try
            {
                return await _myDbContext.EmployeeAddress.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving all addresses: {ex.Message}", ex);
            }
        }

        public async Task<EmployeeAddress?> GetAddressByIdAsync(int addressId)
        {
            try
            {
                return await _myDbContext.EmployeeAddress.FirstOrDefaultAsync(a => a.EmployeeAddressId == addressId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving address with ID {addressId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<EmployeeAddress>> GetAddressesByEmployeeIdAsync(int employeeId)
        {
            try
            {
                return await _myDbContext.EmployeeAddress
                                         .Where(a => a.EmployeeId == employeeId)
                                         .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving addresses for Employee ID {employeeId}: {ex.Message}", ex);
            }
        }

        public async Task<EmployeeAddress> AddAddressAsync(EmployeeAddress address)
        {
            try
            {
                _myDbContext.EmployeeAddress.Add(address);
                await _myDbContext.SaveChangesAsync();
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while adding address for Employee ID {address.EmployeeId}: {ex.Message}", ex);
            }
        }

        public async Task<EmployeeAddress> UpdateAddressAsync(EmployeeAddress address)
        {
            try
            {
                _myDbContext.EmployeeAddress.Update(address);
                await _myDbContext.SaveChangesAsync();
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating address ID {address.EmployeeAddressId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAddressAsync(int addressId)
        {
            try
            {
                var existing = await _myDbContext.EmployeeAddress.FindAsync(addressId);
                if (existing == null)
                    throw new Exception($"Address ID {addressId} not found for deletion.");

                _myDbContext.EmployeeAddress.Remove(existing);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting address ID {addressId}: {ex.Message}", ex);
            }
        }
        public async Task<IEnumerable<ClientAddress>> GetAllClientAddressesAsync()
        {
            try
            {
                return await _myDbContext.ClientAddress.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving all client addresses: {ex.Message}", ex);
            }
        }

        public async Task<ClientAddress?> GetClientAddressByIdAsync(int addressId)
        {
            try
            {
                return await _myDbContext.ClientAddress.FirstOrDefaultAsync(a => a.ClientAddressId == addressId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving client address with ID {addressId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<ClientAddress>> GetClientAddressesByClientIdAsync(int clientId)
        {
            try
            {
                return await _myDbContext.ClientAddress
                                         .Where(a => a.ClientId == clientId)
                                         .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving addresses for Client ID {clientId}: {ex.Message}", ex);
            }
        }

        public async Task<ClientAddress> AddClientAddressAsync(ClientAddress address)
        {
            try
            {
                _myDbContext.ClientAddress.Add(address);
                await _myDbContext.SaveChangesAsync();
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while adding address for Client ID {address.ClientId}: {ex.Message}", ex);
            }
        }

        public async Task<ClientAddress> UpdateClientAddressAsync(ClientAddress address)
        {
            try
            {
                _myDbContext.ClientAddress.Update(address);
                await _myDbContext.SaveChangesAsync();
                return address;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating client address ID {address.ClientAddressId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteClientAddressAsync(int addressId)
        {
            try
            {
                var existing = await _myDbContext.ClientAddress.FindAsync(addressId);
                if (existing == null)
                    throw new Exception($"Client address ID {addressId} not found for deletion.");

                _myDbContext.ClientAddress.Remove(existing);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting client address ID {addressId}: {ex.Message}", ex);
            }
        }
    }
}

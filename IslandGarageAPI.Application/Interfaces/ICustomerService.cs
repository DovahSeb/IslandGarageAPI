using IslandGarageAPI.Application.DTOs;
using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerResponse>> GetAllCustomers();
        Task<CustomerResponse?> GetCustomerById(int id);
        Task<CustomerResponse> AddCustomer(CreateCustomerRequest request);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}

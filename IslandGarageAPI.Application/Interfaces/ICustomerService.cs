using IslandGarageAPI.Application.DTOs;

namespace IslandGarageAPI.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerResponse>> GetAllCustomers();
        Task<CustomerResponse?> GetCustomerById(int id);
        Task<List<CustomerResponse>> AddCustomer(CreateCustomerRequest request);
        Task<CustomerResponse> UpdateCustomer(UpdateCustomerRequest request);
        Task<CustomerResponse> DeleteCustomer(int id);
    }
}

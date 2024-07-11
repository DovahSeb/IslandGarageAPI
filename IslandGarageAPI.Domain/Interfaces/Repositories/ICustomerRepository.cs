using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        Task<List<Customer>> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}

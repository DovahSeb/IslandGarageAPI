using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        Task<List<Customer>> AddCustomer(Customer customer);
        Task<List<Customer>> UpdateCustomer(Customer customer);
        void Delete(int id);
    }
}

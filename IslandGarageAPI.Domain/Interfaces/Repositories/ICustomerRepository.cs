using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        Task<Customer> AddCustomer(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}

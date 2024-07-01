using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}

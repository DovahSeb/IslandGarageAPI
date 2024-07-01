using IslandGarageAPI.Domain.Entities;

namespace IslandGarageAPI.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}

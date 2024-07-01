using IslandGarageAPI.Domain.Entities;
using IslandGarageAPI.Domain.Interfaces.Repositories;
using IslandGarageAPI.Application.Interfaces;

namespace IslandGarageAPI.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}

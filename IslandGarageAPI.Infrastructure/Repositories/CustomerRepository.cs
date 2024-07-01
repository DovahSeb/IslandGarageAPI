using IslandGarageAPI.Domain.Entities;
using IslandGarageAPI.Domain.Interfaces.Repositories;
using IslandGarageAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IslandGarageAPI.Infrastructure.Repositories
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _context;

        public CustomerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();

            return customers;
        }

        public async Task<Customer?> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            return customer;
        }

        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

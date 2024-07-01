using IslandGarageAPI.Domain.Entities;
using IslandGarageAPI.Domain.Interfaces.Repositories;
using IslandGarageAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace IslandGarageAPI.Infrastructure.Repositories
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _context;

        public CustomerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
            var customers = await _context.Customers.Where(x => x.Status != "D").ToListAsync();

            return customers;
        }

        public async Task<Customer?> GetById(int id)
        {
            var customer = await _context.Customers
                                            .Where(x => x.Id.Equals(id) && x.Status != "D")
                                            .FirstOrDefaultAsync();

            return customer;
        }

        public async Task<List<Customer>> AddCustomer(Customer customer)
        {
            customer.CustomerNumber = await GetNextCustomerNumber();
            customer.Status = "I";
            customer.DtAccess = DateTime.Now;
            customer.CreatedAt = DateTime.Now;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return await GetAll();
        }

        public async Task<List<Customer>> UpdateCustomer(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);

            if(existingCustomer is not null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Address = customer.Address;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Email = customer.Email;
                existingCustomer.Status = "M";
                existingCustomer.DtAccess = DateTime.Now;

                _context.Customers.Update(existingCustomer);
                _context.SaveChanges();

                return await GetAll();
            }

            return null;
        }

        public async Task<List<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if(customer is not null)
            {
                customer.Status = "D";
                customer.DtAccess = DateTime.Now;

                _context.Customers.Update(customer);
                _context.SaveChanges();

                return await GetAll();
            }

            return null;
        }

        private async Task<string> GetNextCustomerNumber()
        {
            var lastCustomer = await _context.Customers.OrderByDescending(c => c.CustomerNumber).FirstOrDefaultAsync();
            string lastCustomerNumber = lastCustomer?.CustomerNumber;

            if (string.IsNullOrEmpty(lastCustomerNumber))
            {
                // Return the default customer number if there's no last customer number
                return "IG-000001";
            }

            // Define the regex pattern to match the customer number format
            string pattern = @"IG-(\d{6})";
            var match = Regex.Match(lastCustomerNumber, pattern);

            if (match.Success)
            {
                // Extract the numeric part of the customer number
                string numberPart = match.Groups[1].Value;
                // Parse it to an integer
                int numericValue = int.Parse(numberPart);
                // Increment the numeric value
                numericValue++;
                // Format the new customer number with leading zeros
                string newNumberPart = numericValue.ToString("D6");
                // Return the new customer number
                return $"IG-{newNumberPart}";
            }
            else
            {
                throw new ArgumentException("Invalid customer number format.");
            }
        }
    }
}

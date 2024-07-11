using IslandGarageAPI.Domain.Entities;
using IslandGarageAPI.Domain.Interfaces.Repositories;
using IslandGarageAPI.Application.Interfaces;
using IslandGarageAPI.Application.DTOs;
using AutoMapper;

namespace IslandGarageAPI.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerResponse>> GetAllCustomers()
        {
            var response = await _customerRepository.GetAll();
            
            return _mapper.Map<List<CustomerResponse>>(response);
        }

        public async Task<CustomerResponse?> GetCustomerById(int id)
        {
            var response = await _customerRepository.GetById(id);

            return _mapper.Map<CustomerResponse>(response);
        }

        public async Task<List<CustomerResponse>> AddCustomer(CreateCustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);
            var response = await _customerRepository.AddCustomer(customer);

            return _mapper.Map<List<CustomerResponse>>(response);
        }

        public async Task<CustomerResponse> UpdateCustomer(UpdateCustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);
            var response = await _customerRepository.UpdateCustomer(customer);

            return _mapper.Map<CustomerResponse>(response);
        }

        public async Task<CustomerResponse> DeleteCustomer(int id)
        {
            var response = await _customerRepository.DeleteCustomer(id);

            return _mapper.Map<CustomerResponse>(response);
        }
    }
}

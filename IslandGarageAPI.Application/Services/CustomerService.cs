﻿using IslandGarageAPI.Domain.Entities;
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
